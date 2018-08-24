using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Interfaces.Repositories.Profile;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Interfaces.Services;

namespace SerieList.Domain.Services.Profile
{
    public class PermissionGroupService : ServiceBase<PermissionGroupModel>, IPermissionGroupService
    {
        private readonly IPermissionGroupRepository _permissionGroupRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public PermissionGroupService(IPermissionGroupRepository permissionGroupRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService)
            : base(permissionGroupRepo, tokenProviderRepo)
        {
            _permissionGroupRepo = permissionGroupRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }
        
        public IEnumerable<PermissionGroupModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            var query = _permissionGroupRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdPermissionGroup));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            return query.ToList();
        }

        public void Remove(PermissionGroupModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _permissionGroupRepo.Remove(obj);
        }
    }
}
