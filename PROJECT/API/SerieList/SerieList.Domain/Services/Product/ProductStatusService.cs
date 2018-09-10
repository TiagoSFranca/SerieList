using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Services.Product;
using SerieList.Domain.Interfaces.Repositories.Product;
using System.Collections.Generic;
using System.Linq;
using System;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.CommonEntities;

namespace SerieList.Domain.Services.Product
{
    public class ProductStatusService : ServiceBase<ProductStatusModel>, IProductStatusService
    {
        private readonly IProductStatusRepository _productStatusRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public ProductStatusService(IProductStatusRepository prductStatusRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService,
            IConfigurationRepository configurationRepo)
            : base(prductStatusRepo, tokenProviderRepo, configurationRepo)
        {
            _productStatusRepo = prductStatusRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public PagingResultModel<ProductStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging)
        {
            var query = _productStatusRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdProductStatus));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            query = query.OrderBy(e => e.Description);

            return Paginate(query, paging);
        }

        public void Remove(ProductStatusModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _productStatusRepo.Remove(obj);
        }

    }
}
