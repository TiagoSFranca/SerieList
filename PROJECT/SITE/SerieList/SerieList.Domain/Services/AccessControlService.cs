using SerieList.Domain.Interfaces.Services;
using System;
using System.Linq;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Interfaces.Repositories.Profile;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Token;
using SerieList.Domain.Seed;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using SerieList.Domain.Seed.Token;
using SerieList.Extras.Util.Crypt;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages;
using SerieList.Domain.Entitites.Token;
using System.Net.Mail;

namespace SerieList.Domain.Services
{
    public class AccessControlService : IAccessControlService
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPasswordHistoryRepository _passwordHistoryRepository;

        private readonly IConfigurationService _configService;
        private readonly ITokenProviderService _tokenProviderService;

        private AccessControlServiceMessage accessControlServiceMessage;
        private TokenProviderServiceMessage tokenProviderMessage;

        public AccessControlService(IUserRepository UserRepo, IConfigurationService configService,
            ITokenProviderService tokenProviderService, ITokenProviderRepository tokenProviderRepo, IPermissionRepository permisionRepository,
            IPasswordHistoryRepository passwordHistoryRepository)
        {
            _configService = configService;
            _tokenProviderService = tokenProviderService;

            _userRepo = UserRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _permissionRepository = permisionRepository;
            _passwordHistoryRepository = passwordHistoryRepository;

            accessControlServiceMessage = new AccessControlServiceMessage();
            tokenProviderMessage = new TokenProviderServiceMessage();
        }

        public bool EmailExists(string email)
        {
            return _userRepo.Query().Where(u => u.UserInfo.Email == email).Count() > 0;
        }

        public bool UserNameExists(string username)
        {
            return _userRepo.Query().Where(u => u.UserInfo.UserName == username).Count() > 0;
        }

        private bool ValidatePasswordLength(string password, int length)
        {
            return password.Trim().Length >= length;
        }

        public string ValidatePassword(string password)
        {
            string error = string.Empty;
            var minPasswordLength = _configService.GetValueByKey(ConfigurationSeed.MinPasswordLength.Key);
            if (minPasswordLength != null)
            {
                int length;
                Int32.TryParse(minPasswordLength, out length);
                if (length > 0 && !ValidatePasswordLength(password, length))
                    error += accessControlServiceMessage.PasswordInvalidLength(length);
            }
            return error;
        }

        public string ValidateEmail(string email)
        {
            string error = string.Empty;
            try
            {
                var addr = new MailAddress(email);
            }
            catch
            {
                error += accessControlServiceMessage.EmailInvalid(email);
            }
            return error;
        }

        public string ValidateUserName(string userName)
        {
            string error = string.Empty;
            if (userName.Contains(" "))
                error += accessControlServiceMessage.UserNameWithWhiteSpace;
            return error;
        }

        public string Register(UserModel user)
        {
            string error = string.Empty;

            if ((error = this.ValidateEmail(user.UserInfo.Email)).Length > 0)
                throw new ServiceException(error);
            if ((error = this.ValidateUserName(user.UserInfo.UserName)).Length > 0)
                throw new ServiceException(error);
            if (this.EmailExists(user.UserInfo.Email))
                throw new ServiceException(accessControlServiceMessage.EmailExists(user.UserInfo.Email));
            if (this.UserNameExists(user.UserInfo.UserName))
                throw new ServiceException(accessControlServiceMessage.UserNameExists(user.UserInfo.UserName));
            if ((error = this.ValidatePassword(user.UserInfo.PasswordHash)).Length > 0)
                throw new ServiceException(error);

            string password = SHA1Crypt.Encrypt(user.UserInfo.PasswordHash);
            user.UserInfo.PasswordHash = password;
            user.UserInfo.SecurityStamp = Guid.NewGuid().ToString();

            _userRepo.Add(user);

            _passwordHistoryRepository.Add(new PasswordHistoryModel()
            {
                Password = password,
                IdUser = user.IdUser
            });

            return _tokenProviderService.CreateToken(TokenProviderTypeSeed.ConfirmEmail.IdTokenProviderType, user, false);
        }

        public void ConfirmMail(string token)
        {
            var tokenProvider = _tokenProviderService.GetByToken(token);
            if (tokenProvider == null)
                throw new ServiceException(tokenProviderMessage.TokenNotFound);

            tokenProvider.Validate();

            tokenProvider.Valid = false;
            _tokenProviderService.Update(tokenProvider, tokenProvider.User);

            var user = _userRepo.GetById((int)tokenProvider.IdUser);
            user.UserInfo.EmailConfirmed = true;
            _userRepo.Update(user);
        }

        public string Authenticate(string login, string password, bool keep)
        {
            var passwordEncrypted = SHA1Crypt.Encrypt(password);
            var user = _userRepo.Query().FirstOrDefault(e => (e.UserInfo.UserName.Equals(login) || e.UserInfo.Email.Equals(login)) && e.UserInfo.PasswordHash.Equals(passwordEncrypted));
            if (user == null)
                throw new ServiceException(accessControlServiceMessage.LoginInvalid);
            user.IsGranted();
            var token = _tokenProviderService.CreateToken(TokenProviderTypeSeed.Authentication.IdTokenProviderType, user, keep);
            return token;
        }

        public void Authorize(UserModel user, int idPermission)
        {
            user.IsGranted();
            user.HasPermission(_permissionRepository.GetById(idPermission));
        }

        public void Unauthenticate(string token)
        {
            var tokenProvider = _tokenProviderService.GetByToken(token);
            if (tokenProvider == null)
                throw new ServiceException(tokenProviderMessage.TokenNotFound);

            tokenProvider.Validate();

            tokenProvider.Valid = false;
            _tokenProviderService.Update(tokenProvider, tokenProvider.User);
        }

        public string ForgotPassword(string email)
        {
            var user = _userRepo.Query().FirstOrDefault(u => u.UserInfo.Email == email);
            if (user == null)
                throw new ServiceException(accessControlServiceMessage.EmailExists(email));

            return _tokenProviderService.CreateToken(TokenProviderTypeSeed.ResetPassword.IdTokenProviderType, user, false);
        }

        public void ResetPassword(TokenProviderModel tokenProvider, string newPassword, string confirmPassword)
        {
            string passwordError = string.Empty;

            if (tokenProvider.IdTokenProviderType != (int)TokenProviderTypeSeed.ResetPassword.IdTokenProviderType)
                throw new ServiceException(tokenProviderMessage.TokenInvalid);
            if ((passwordError = this.ValidatePassword(newPassword)).Length > 0)
                throw new ServiceException(passwordError);
            if (!newPassword.Equals(confirmPassword))
                throw new ServiceException(accessControlServiceMessage.PasswordError);

            string password = SHA1Crypt.Encrypt(newPassword);

            ExistsByUserAndPassword((int)tokenProvider.IdUser, password);

            var user = _userRepo.GetById((int)tokenProvider.IdUser);
            user.UserInfo.PasswordHash = password;
            _userRepo.Update(user);

            _passwordHistoryRepository.Add(new PasswordHistoryModel()
            {
                Password = password,
                IdUser = user.IdUser
            });

            tokenProvider.Valid = false;
            _tokenProviderService.Update(tokenProvider, tokenProvider.User);
        }

        private void ExistsByUserAndPassword(int idUser, string password)
        {
            var result = _passwordHistoryRepository.Query().Where(e => e.IdUser == idUser && e.Password.Equals(password)).ToList();
            if (result.Count > 0)
                throw new ServiceException(accessControlServiceMessage.PasswordHasUsed);
        }
    }
}
