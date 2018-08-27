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
using SerieList.Domain.Interfaces.Repositories;

namespace SerieList.Domain.Services.Profile
{
    public class PermissionTypeService : ServiceBase<PermissionTypeModel>, IPermissionTypeService
    {
        private readonly IPermissionTypeRepository _permissionTypeRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public PermissionTypeService(IPermissionTypeRepository permissionTypeRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService,
            IConfigurationRepository configurationRepo)
            : base(permissionTypeRepo, tokenProviderRepo, configurationRepo)
        {
            _permissionTypeRepo = permissionTypeRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public IEnumerable<PermissionTypeModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            var query = _permissionTypeRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdPermissionType));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            return query.ToList();
        }

        public void Remove(PermissionTypeModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _permissionTypeRepo.Remove(obj);
        }

    }
}
