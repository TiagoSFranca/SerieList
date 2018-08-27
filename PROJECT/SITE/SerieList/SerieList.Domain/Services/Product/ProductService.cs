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
    public class ProductService : ServiceBase<ProductModel>, IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;
        private readonly IProductCategoryRepository _productCategoryRepo;

        private readonly IAccessControlService _accessControlService;

        private ProductCategoryServiceMessage productCategoryMessage;
        private ProductServiceMessage productMessage;

        public ProductService(IProductRepository productRepo, ITokenProviderRepository tokenProviderRepo, IProductCategoryRepository productCategoryRepo,
            IAccessControlService accessControlService, IConfigurationRepository configurationRepo)
            : base(productRepo, tokenProviderRepo, configurationRepo)
        {
            _productRepo = productRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _productCategoryRepo = productCategoryRepo;
            _accessControlService = accessControlService;
            productCategoryMessage = new ProductCategoryServiceMessage();
            productMessage = new ProductServiceMessage();
        }

        public IEnumerable<ProductModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductTypeList,
            IEnumerable<int> idProductStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded)
        {
            var query = _productRepo.Query();

            if (excluded != null)
                query = query.Where(p => p.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(p => idList.Contains(p.IdProduct));

            if (idProductTypeList?.Count() > 0)
                query = query.Where(p => idProductTypeList.Contains(p.ProductType.IdProductType));

            if (idProductStatusList?.Count() > 0)
                query = query.Where(p => idProductStatusList.Contains(p.ProductStatus.IdProductStatus));

            if (idVisibilityList?.Count() > 0)
                query = query.Where(p => idVisibilityList.Contains(p.Visibility.IdVisibility));

            if (idUserList?.Count() > 0)
                query = query.Where(p => idUserList.Contains(p.User.IdUser));

            if (!String.IsNullOrEmpty(title))
                query = query.Where(p => p.ProductInfo.Title.ToLower().Contains(title.ToLower()));

            var dataResult = query.ToList();

            if (associatedExcluded != null)
                dataResult = dataResult.Where(p => p.AssociationExcluded((bool)associatedExcluded) != null).ToList();

            return dataResult;
        }

        public void Add(ProductModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.ProductAdd.IdPermission);
            this.ValidateCategories(obj);
            obj.IdUser = userCredentials.IdUser;
            _productRepo.Add(obj);
        }

        public void Update(ProductModel obj, UserModel userCredentials)
        {
            var product = _productRepo.GetById(obj.IdProduct, true);
            if (product == null)
                throw new ServiceException(productMessage.NotFound);
            product.ValidateExcluded();
            this.ValidateUser(userCredentials, PermissionSeed.ProductUpdate.IdPermission, obj);
            this.ValidateCategories(obj);
            obj.IdUser = product.IdUser;
            _productRepo.Update(obj);
        }

        public void Remove(ProductModel obj, UserModel userCredentials)
        {
            this.ValidateUser(userCredentials, PermissionSeed.ProductRemove.IdPermission, obj);
            _productRepo.Remove(obj);
        }

        private void ValidateUser(UserModel userCredentials, int idPermission, ProductModel obj)
        {
            var product = _productRepo.GetById(obj.IdProduct, true);
            if (product == null)
                throw new ServiceException(productMessage.NotFound);
            _accessControlService.Authorize(userCredentials, idPermission);
            bool isAdmin = userCredentials.Profile.Permissions.Any(e => e.IdPermission == PermissionSeed.Admin.IdPermission);
            if (product.IdUser != userCredentials.IdUser && !isAdmin)
                throw new ServiceException(productMessage.UserInvalid);
        }


        private void ValidateCategories(ProductModel obj)
        {
            foreach (var category in obj.Categories)
            {
                if (_productCategoryRepo.GetById(category.IdCategory, true) == null)
                    throw new ServiceException(productCategoryMessage.ElementNotExists(category.IdCategory));
            }
        }

    }
}
