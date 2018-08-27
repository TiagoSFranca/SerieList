using SerieList.Application.Interfaces.Product;
using SerieList.Domain.Entitites.Product;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.AppModels.Product;
using SerieList.Domain.Interfaces.Services.Product;
using SerieList.Application.Extensions.Product;
using System;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Interfaces.Services;

namespace SerieList.Application.Concrete.Product
{
    public class ProductTypeAppService : AppServiceBase<ProductTypeModel>, IProductTypeAppService
    {
        private readonly IProductTypeService _productTypeService;
        private readonly ITokenProviderService _tokenProviderService;

        public ProductTypeAppService(IProductTypeService productTypeService, ITokenProviderService tokenProviderService,
            IConfigurationService configurationService)
            : base(productTypeService, tokenProviderService, configurationService)
        {
            _productTypeService = productTypeService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(ProductTypeAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var productType = obj.MapperToDomain();
                _productTypeService.Add(productType, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public ProductTypeAppModel GetById(int id)
        {
            try
            {
                return _productTypeService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public IEnumerable<ProductTypeAppModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            try
            {
                return _productTypeService.Query(idList, description, excluded).Select(e => e.MapperToAppModel()).ToList();
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
                var product = _productTypeService.GetById(id);
                _productTypeService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(ProductTypeAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var productType = obj.MapperToDomain();
                _productTypeService.Update(productType, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
