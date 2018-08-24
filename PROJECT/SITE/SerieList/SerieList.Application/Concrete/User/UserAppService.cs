using SerieList.Application.Interfaces.User;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.AppModels.User;
using SerieList.Application.Extensions.User;
using SerieList.Domain.Mail.Interfaces;
using SerieList.Domain.Mail.Entities;
using SerieList.Application.Mail.Interfaces;
using SerieList.Extras.Util.Crypt;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Seed.Token;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Seed;
using System.Threading.Tasks;

namespace SerieList.Application.Concrete.User
{
    public class UserAppService : AppServiceBase<UserModel>, IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly ITokenProviderService _tokenProviderService;
        private readonly IConfigurationService _configService;

        private readonly IMailTemplate _mailTemplate;

        public UserAppService(IUserService userService, IMailService mailService, IMailTemplate mailTemplate, ITokenProviderService tokenProviderService,
            IConfigurationService configService)
            : base(userService, tokenProviderService)
        {
            _userService = userService;
            _mailService = mailService;
            _mailTemplate = mailTemplate;
            _tokenProviderService = tokenProviderService;
            _configService = configService;
        }

        public void Add(UserAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var user = obj.MapperToDomain();
                _userService.Add(user, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
        
        public UserAppModel GetById(int id)
        {
            try
            {
                return _userService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
        
        public IEnumerable<UserAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProfileList, IEnumerable<int> idUserStatusList, string firstName, string lastName, string email, string userName, bool? excluded, bool? associatedExcluded)
        {
            try
            {
                return _userService
                    .Query(idList, idProfileList, idUserStatusList, firstName, lastName, email, userName, excluded, associatedExcluded)
                    .Select(e => e.MapperToAppModel()).ToList();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
        
        public void Remove(int id, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var user = _userService.GetById(id);
                _userService.Remove(user, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(UserAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var user = obj.MapperToDomain();
                _userService.Update(user, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
        
    }
}
