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
    public class UserSeasonStatusService : ServiceBase<UserSeasonStatusModel>, IUserSeasonStatusService
    {
        private readonly IUserSeasonStatusRepository _userSeasonStatusRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public UserSeasonStatusService(IUserSeasonStatusRepository userSeasonStatusRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService,
            IConfigurationRepository configurationRepo)
            : base(userSeasonStatusRepo, tokenProviderRepo, configurationRepo)
        {
            _userSeasonStatusRepo = userSeasonStatusRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public PagingResultModel<UserSeasonStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging)
        {
            var query = _userSeasonStatusRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdUserSeasonStatus));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            query = query.OrderBy(e => e.Description);

            return Paginate(query, paging);
        }

        public void Remove(UserSeasonStatusModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _userSeasonStatusRepo.Remove(obj);
        }
    }
}
