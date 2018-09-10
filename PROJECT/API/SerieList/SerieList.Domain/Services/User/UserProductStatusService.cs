using SerieList.Domain.CommonEntities;
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
    public class UserProductStatusService : ServiceBase<UserProductStatusModel>, IUserProductStatusService
    {
        private readonly IUserProductStatusRepository _userProductStatusRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public UserProductStatusService(IUserProductStatusRepository userProductStatusRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService,
            IConfigurationRepository configurationRepo)
            : base(userProductStatusRepo, tokenProviderRepo, configurationRepo)
        {
            _userProductStatusRepo = userProductStatusRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public PagingResultModel<UserProductStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging)
        {
            var query = _userProductStatusRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdUserProductStatus));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            query = query.OrderBy(e => e.Description);

            return Paginate(query, paging);
        }

        public void Remove(UserProductStatusModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _userProductStatusRepo.Remove(obj);
        }
    }
}
