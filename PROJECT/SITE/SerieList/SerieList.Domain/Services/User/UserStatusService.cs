using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Services.User;
using SerieList.Domain.Seed.Profile;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SerieList.Domain.Services.User
{
    public class UserStatusService : ServiceBase<UserStatusModel>, IUserStatusService
    {
        private readonly IUserStatusRepository _userStatusRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public UserStatusService(IUserStatusRepository userStatusRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService,
            IConfigurationRepository configurationRepo)
            : base(userStatusRepo, tokenProviderRepo, configurationRepo)
        {
            _userStatusRepo = userStatusRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public IEnumerable<UserStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            var query = _userStatusRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdUserStatus));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            return query.ToList();
        }

        public void Remove(UserStatusModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _userStatusRepo.Remove(obj);
        }
    }
}
