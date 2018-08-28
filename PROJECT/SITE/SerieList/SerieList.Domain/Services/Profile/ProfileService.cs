using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Profile;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Services.Profile;
using SerieList.Domain.Seed.Profile;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Profile;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SerieList.Domain.Services.Profile
{
    public class ProfileService : ServiceBase<ProfileModel>, IProfileService
    {
        private readonly IProfileRepository _profileRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;
        private readonly IPermissionRepository _permissionRepo;

        private readonly IAccessControlService _accessControlService;

        private ProfileServiceMessage profileMessage;

        public ProfileService(IProfileRepository profileRepo, IPermissionRepository permissionRepo, ITokenProviderRepository tokenProviderRepo,
            IAccessControlService accessControlService, IConfigurationRepository configurationRepo)
            : base(profileRepo, tokenProviderRepo, configurationRepo)
        {
            _profileRepo = profileRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _permissionRepo = permissionRepo;
            _accessControlService = accessControlService;
            profileMessage = new ProfileServiceMessage();
        }

        public PagingResultModel<ProfileModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging)
        {
            var query = _profileRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdProfile));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            query = query.OrderBy(e => e.Description);

            return Paginate(query, paging);
        }

        public void Add(ProfileModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.ProfileAdd.IdPermission);
            this.ValidatePermissions(obj);
            _profileRepo.Add(obj);
        }

        public void Update(ProfileModel obj, UserModel userCredentials)
        {
            var profile = _profileRepo.GetById(obj.IdProfile, true);
            if (profile == null)
                throw new ServiceException(profileMessage.NotFound);
            profile.ValidateExcluded();
            _accessControlService.Authorize(userCredentials, PermissionSeed.ProfileUpdate.IdPermission);
            this.ValidatePermissions(obj);
            _profileRepo.Update(obj);
        }

        public void Remove(ProfileModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.ProfileRemove.IdPermission);
            _profileRepo.Remove(obj);
        }

        private void ValidatePermissions(ProfileModel obj)
        {
            foreach (var profilePermission in obj.Permissions)
            {
                if (_permissionRepo.GetById(profilePermission.IdPermission) == null)
                    throw new ServiceException(profileMessage.ElementNotExists(profilePermission.IdPermission));
            }
        }

    }
}
