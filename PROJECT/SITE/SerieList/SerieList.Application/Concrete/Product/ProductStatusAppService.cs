using SerieList.Application.AppModels.Product;
using SerieList.Application.Interfaces.Product;
using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Services.Product;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.Extensions.Product;
using System;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Interfaces.Services;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;

namespace SerieList.Application.Concrete.Product
{
    public class ProductStatusAppService : AppServiceBase<ProductStatusModel>, IProductStatusAppService
    {
        private readonly IProductStatusService _productStatusService;
        private readonly ITokenProviderService _tokenProviderService;

        public ProductStatusAppService(IProductStatusService productStatusService, ITokenProviderService tokenProviderService)
            : base(productStatusService, tokenProviderService)
        {
            _productStatusService = productStatusService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(ProductStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var productStatus = obj.MapperToDomain();
                _productStatusService.Add(productStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public ProductStatusAppModel GetById(int id)
        {
            try
            {
                return _productStatusService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<ProductStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _productStatusService.Query(idList, description, excluded, paging);
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
                var product = _productStatusService.GetById(id);
                _productStatusService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(ProductStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var productStatus = obj.MapperToDomain();
                _productStatusService.Update(productStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
