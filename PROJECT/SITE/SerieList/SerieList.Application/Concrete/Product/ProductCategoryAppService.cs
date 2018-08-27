using SerieList.Application.AppModels.Product;
using SerieList.Application.Interfaces.Product;
using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Services.Product;
using System;
using System.Collections.Generic;
using SerieList.Application.Extensions.Product;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.CommonEntities;
using SerieList.Application.CommonAppModels;

namespace SerieList.Application.Concrete.Product
{
    public class ProductCategoryAppService : AppServiceBase<ProductCategoryModel>, IProductCategoryAppService
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly ITokenProviderService _tokenProviderService;

        public ProductCategoryAppService(IProductCategoryService productCategoryService, ITokenProviderService tokenProviderService)
            : base(productCategoryService, tokenProviderService)
        {
            _productCategoryService = productCategoryService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(ProductCategoryAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var product = obj.MapperToDomain();
                _productCategoryService.Add(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public ProductCategoryAppModel GetById(int id)
        {
            try
            {
                return _productCategoryService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<ProductCategoryAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _productCategoryService.Query(idList, description, excluded, paging);
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
                var product = _productCategoryService.GetById(id);
                _productCategoryService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(ProductCategoryAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var product = obj.MapperToDomain();
                _productCategoryService.Update(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
