using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Product;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Services.Product;
using SerieList.Domain.Seed.Profile;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Product;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SerieList.Domain.Services.Product
{
    public class ProductCategoryService : ServiceBase<ProductCategoryModel>, IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        private ProductCategoryServiceMessage productMessage;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService,
            IConfigurationRepository configurationRepo)
            : base(productCategoryRepo, tokenProviderRepo, configurationRepo)
        {
            _productCategoryRepo = productCategoryRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
            productMessage = new ProductCategoryServiceMessage();
        }

        public PagingResultModel<ProductCategoryModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging)
        {
            var query = _productCategoryRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdProductCategory));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            query = query.OrderBy(e => e.Description);

            return Paginate(query, paging);
        }

        public void Add(ProductCategoryModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.ProductCategoryAdd.IdPermission);
            this.ValidateDescription(obj);
            _productCategoryRepo.Add(obj);
        }

        public void Update(ProductCategoryModel obj, UserModel userCredentials)
        {
            var productCategory = _productCategoryRepo.GetById(obj.IdProductCategory, true);
            if (productCategory == null)
                throw new ServiceException(productMessage.NotFound);
            productCategory.ValidateExcluded();
            _accessControlService.Authorize(userCredentials, PermissionSeed.ProductCategoryUpdate.IdPermission);
            this.ValidateDescription(obj);
            _productCategoryRepo.Update(obj);
        }

        public void Remove(ProductCategoryModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.ProductCategoryRemove.IdPermission);
            _productCategoryRepo.Remove(obj);
        }

        private void ValidateDescription(ProductCategoryModel obj)
        {
            var query = _productCategoryRepo.Query();
            query = query.Where(e => e.Description.ToLower() == obj.Description.ToLower() && e.IdProductCategory != obj.IdProductCategory);
            if (query.Count() > 0)
                throw new ServiceException(productMessage.DescriptionExists);
        }

    }
}
