using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Services.Product;
using SerieList.Domain.Interfaces.Repositories.Product;
using System.Collections.Generic;
using System.Linq;
using System;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Interfaces.Services.User;
using SerieList.Domain.Interfaces.Services;

namespace SerieList.Domain.Services.Product
{
    public class ProductStatusService : ServiceBase<ProductStatusModel>, IProductStatusService
    {
        private readonly IProductStatusRepository _productStatusRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public ProductStatusService(IProductStatusRepository prductStatusRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService)
            : base(prductStatusRepo, tokenProviderRepo)
        {
            _productStatusRepo = prductStatusRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public IEnumerable<ProductStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            var query = _productStatusRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdProductStatus));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            return query.ToList();
        }

        public void Remove(ProductStatusModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _productStatusRepo.Remove(obj);
        }

    }
}
