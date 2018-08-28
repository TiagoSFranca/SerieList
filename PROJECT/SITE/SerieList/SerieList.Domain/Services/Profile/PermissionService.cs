using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Interfaces.Repositories.Profile;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services.Profile;
using System.Collections.Generic;
using System.Linq;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.CommonEntities;

namespace SerieList.Domain.Services.Profile
{
    public class PermissionService : ServiceBase<PermissionModel>, IPermissionService
    {
        private readonly IPermissionRepository _permissionRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public PermissionService(IPermissionRepository permissionRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService,
            IConfigurationRepository configurationRepo)
            : base(permissionRepo, tokenProviderRepo, configurationRepo)
        {
            _permissionRepo = permissionRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public PagingResultModel<PermissionModel> Query(IEnumerable<int> idList, IEnumerable<int> idPermissionTypeList,
            IEnumerable<int> idPermissionGroupList, bool? excluded, bool? associatedExcluded, PagingModel paging)
        {
            var query = _permissionRepo.Query();

            if (excluded != null)
                query = query.Where(p => p.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(p => idList.Contains(p.IdPermission));

            if (idPermissionTypeList?.Count() > 0)
                query = query.Where(p => idPermissionTypeList.Contains(p.IdPermissionType));

            if (idPermissionGroupList?.Count() > 0)
                query = query.Where(p => idPermissionGroupList.Contains(p.IdPermissionGroup));

            var dataResult = query.ToList();

            if (associatedExcluded != null)
                dataResult = dataResult.Where(p => p.AssociationExcluded((bool)associatedExcluded) != null).ToList();

            return Paginate(dataResult, paging);
        }

        public void Remove(PermissionModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _permissionRepo.Remove(obj);
        }
    }
}
