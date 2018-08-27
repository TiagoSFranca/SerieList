using SerieList.Application.AppModels.User;
using SerieList.Application.Interfaces;
using SerieList.Application.Mail.Interfaces;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Mail.Entities;
using SerieList.Domain.Mail.Interfaces;
using SerieList.Domain.Seed;
using System;
using System.Threading.Tasks;
using SerieList.Extras.Util.Crypt;
using SerieList.Application.Extensions.User;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Services.User;

namespace SerieList.Application.Concrete
{
    public class AccessControlAppService : AppServiceBase<UserModel>, IAccessControlAppService
    {
        private readonly IAccessControlService _accessControlService;
        private readonly IMailService _mailService;
        private readonly ITokenProviderService _tokenProviderService;
        private readonly IConfigurationService _configService;
        private readonly IUserService _userService;

        private readonly IMailTemplate _mailTemplate;

        public AccessControlAppService(IAccessControlService accessControlService, IMailService mailService, IMailTemplate mailTemplate, ITokenProviderService tokenProviderService,
            IConfigurationService configurationService, IUserService userService)
            : base(userService, tokenProviderService, configurationService)
        {
            _accessControlService = accessControlService;
            _mailService = mailService;
            _mailTemplate = mailTemplate;
            _tokenProviderService = tokenProviderService;
            _configService = configurationService;
            _userService = userService;
        }

        public bool EmailExists(string email)
        {
            try
            {
                return _accessControlService.EmailExists(email);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public string ValidatePassword(string password)
        {
            try
            {
                return _accessControlService.ValidatePassword(password);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Register(UserAppModel obj)
        {
            try
            {
                var user = obj.MapperToDomain();

                string token = _accessControlService.Register(user);

                SingleDestinationMailModel mailModel = new SingleDestinationMailModel(obj.UserInfo.Email);
                mailModel.Body = _mailTemplate.GetRegisterTemplate(obj.UserInfo.FirstName, obj.UserInfo.UserName, MD5Crypt.Encrypt(token));
                mailModel.Subject = _configService.GetValueByKey(ConfigurationSeed.MailTitleRegister.Key);
                Task.Factory.StartNew(() => _mailService.SendSingleDestinationMail(mailModel));
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public bool UserNameExists(string username)
        {
            try
            {
                return _accessControlService.UserNameExists(username);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void ConfirmMail(string token)
        {
            try
            {
                _accessControlService.ConfirmMail(MD5Crypt.Decrypt(token));
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public string Authenticate(string login, string password, bool keep)
        {
            try
            {
                return _accessControlService.Authenticate(login, password, keep);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Unauthenticate(string token)
        {
            try
            {
                _accessControlService.Unauthenticate(token);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void ForgotPassword(string email)
        {
            try
            {
                var token = _accessControlService.ForgotPassword(email);
                var tokenProvider = _tokenProviderService.GetByToken(token);
                var user = _userService.GetById((int)tokenProvider.IdUser);
                SingleDestinationMailModel mailModel = new SingleDestinationMailModel(email);
                mailModel.Body = _mailTemplate.GetForgotPasswordTemplate(user.UserInfo.FirstName, MD5Crypt.Encrypt(token));
                mailModel.Subject = _configService.GetValueByKey(ConfigurationSeed.MailTitleForgotPassword.Key);
                Task.Factory.StartNew(() => _mailService.SendSingleDestinationMail(mailModel));
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void ResetPassword(string token, string newPassword, string confirmPassword)
        {
            try
            {
                var tokenProvider = ValidateToken(MD5Crypt.Decrypt(token));
                _accessControlService.ResetPassword(tokenProvider, newPassword, confirmPassword);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
