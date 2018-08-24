using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Interfaces.Repositories.Season;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services.Season;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Interfaces.Services;

namespace SerieList.Domain.Services.Season
{
    public class SeasonStatusService : ServiceBase<SeasonStatusModel>, ISeasonStatusService
    {
        private readonly ISeasonStatusRepository _seasonStatusRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public SeasonStatusService(ISeasonStatusRepository seasonStatusRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService)
            : base(seasonStatusRepo, tokenProviderRepo)
        {
            _seasonStatusRepo = seasonStatusRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }
        
        public IEnumerable<SeasonStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            var query = _seasonStatusRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdSeasonStatus));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            return query.ToList();
        }

        public void Remove(SeasonStatusModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _seasonStatusRepo.Remove(obj);
        }

    }
}
