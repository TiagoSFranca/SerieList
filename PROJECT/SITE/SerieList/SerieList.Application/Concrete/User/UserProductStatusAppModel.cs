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
    public class UserProductStatusAppService : AppServiceBase<UserProductStatusModel>, IUserProductStatusAppService
    {
        private readonly IUserProductStatusService _userProductStatusService;
        private readonly ITokenProviderService _tokenProviderService;

        public UserProductStatusAppService(IUserProductStatusService userProductStatusService, ITokenProviderService tokenProviderService)
            : base(userProductStatusService, tokenProviderService)
        {
            _userProductStatusService = userProductStatusService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(UserProductStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userProductStatus = obj.MapperToDomain();
                _userProductStatusService.Add(userProductStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserProductStatusAppModel GetById(int id)
        {
            try
            {
                return _userProductStatusService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<UserProductStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _userProductStatusService.Query(idList, description, excluded, paging);
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
                var userProductStatus = _userProductStatusService.GetById(id);
                _userProductStatusService.Remove(userProductStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(UserProductStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userProductStatus = obj.MapperToDomain();
                _userProductStatusService.Update(userProductStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
