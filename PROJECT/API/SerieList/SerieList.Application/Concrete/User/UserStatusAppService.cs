using SerieList.Application.AppModels.User;
using SerieList.Application.Interfaces.User;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using SerieList.Application.Extensions.User;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.CommonEntities;
using SerieList.Application.CommonAppModels;

namespace SerieList.Application.Concrete.User
{
    public class UserStatusAppService : AppServiceBase<UserStatusModel>, IUserStatusAppService
    {
        private readonly IUserStatusService _userStatusService;
        private readonly ITokenProviderService _tokenProviderService;

        public UserStatusAppService(IUserStatusService userStatusService, ITokenProviderService tokenProviderService)
            : base(userStatusService, tokenProviderService)
        {
            _userStatusService = userStatusService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(UserStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userStatus = obj.MapperToDomain();
                _userStatusService.Add(userStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserStatusAppModel GetById(int id)
        {
            try
            {
                return _userStatusService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<UserStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _userStatusService.Query(idList, description, excluded, paging);
                return result.MapperToAppModel();
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
                var userStatus = _userStatusService.GetById(id);
                _userStatusService.Remove(userStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(UserStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userStatus = obj.MapperToDomain();
                _userStatusService.Update(userStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
