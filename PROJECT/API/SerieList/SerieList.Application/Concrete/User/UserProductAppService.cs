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
    public class UserProductAppService : AppServiceBase<UserProductModel>, IUserProductAppService
    {
        private readonly IUserProductService _userProductService;
        private readonly ITokenProviderService _tokenProviderService;

        public UserProductAppService(IUserProductService userProductService, ITokenProviderService tokenProviderService)
            : base(userProductService, tokenProviderService)
        {
            _userProductService = userProductService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(UserProductAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userProduct = obj.MapperToDomain();
                _userProductService.Add(userProduct, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserProductAppModel GetById(int id)
        {
            try
            {
                return _userProductService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<UserProductAppModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idProductList,
            IEnumerable<int> idUserProductStatusList, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _userProductService.Query(idUserList, idProductList, idUserProductStatusList, excluded, associatedExcluded, paging);
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
                var userProduct = _userProductService.GetById((int)tokenProvider.IdUser, id);
                _userProductService.Remove(userProduct, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(UserProductAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userProduct = obj.MapperToDomain();
                _userProductService.Update(userProduct, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserProductAppModel GetById(string token, int idProduct)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                return _userProductService.GetById((int)tokenProvider.IdUser, idProduct).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
