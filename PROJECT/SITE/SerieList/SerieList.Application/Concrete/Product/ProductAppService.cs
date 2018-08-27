using SerieList.Application.Interfaces.Product;
using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.AppModels.Product;
using SerieList.Application.Extensions.Product;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Interfaces.Services;

namespace SerieList.Application.Concrete.Product
{
    public class ProductAppService : AppServiceBase<ProductModel>, IProductAppService
    {
        private readonly IProductService _productService;
        private readonly ITokenProviderService _tokenProviderService;

        public ProductAppService(IProductService productService, ITokenProviderService tokenProviderService,
            IConfigurationService configurationService)
            : base(productService, tokenProviderService, configurationService)
        {
            _productService = productService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(ProductAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var product = obj.MapperToDomain();
                _productService.Add(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public ProductAppModel GetById(int id)
        {
            try
            {
                return _productService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public IEnumerable<ProductAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductTypeList,
            IEnumerable<int> idProductStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded)
        {
            try
            {
                return _productService
                    .Query(idList, idProductTypeList, idProductStatusList, idVisibilityList, idUserList, title, excluded, associatedExcluded)
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
                var product = _productService.GetById(id);
                _productService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(ProductAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var product = obj.MapperToDomain();
                _productService.Update(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
