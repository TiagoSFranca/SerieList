using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Repositories.Product;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Interfaces.Services;

namespace SerieList.Domain.Services.Product
{
    public class VisibilityService : ServiceBase<VisibilityModel>, IVisibilityService
    {
        private readonly IVisibilityRepository _visibilityRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public VisibilityService(IVisibilityRepository visibilityRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService)
            : base(visibilityRepo, tokenProviderRepo)
        {
            _visibilityRepo = visibilityRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public IEnumerable<VisibilityModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            var query = _visibilityRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdVisibility));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            return query.ToList();
        }
                
        public void Remove(VisibilityModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _visibilityRepo.Remove(obj);
        }
    }
}
