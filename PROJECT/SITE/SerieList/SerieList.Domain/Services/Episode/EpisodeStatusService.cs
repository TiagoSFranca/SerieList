using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Interfaces.Repositories.Episode;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Interfaces.Repositories;

namespace SerieList.Domain.Services.Episode
{
    public class EpisodeStatusService : ServiceBase<EpisodeStatusModel>, IEpisodeStatusService
    {
        private readonly IEpisodeStatusRepository _episodeStatusRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        public EpisodeStatusService(IEpisodeStatusRepository episodeStatusRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService,
            IConfigurationRepository configurationRepo)
            : base(episodeStatusRepo, tokenProviderRepo, configurationRepo)
        {
            _episodeStatusRepo = episodeStatusRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
        }

        public PagingResultModel<EpisodeStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging)
        {
            var query = _episodeStatusRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdEpisodeStatus));

            if (!String.IsNullOrEmpty(description))
                query = query.Where(pt => pt.Description.ToLower().Contains(description.ToLower()));

            query = query.OrderBy(e => e.Description);

            return Paginate(query, paging);
        }

        public void Remove(EpisodeStatusModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.Admin.IdPermission);
            _episodeStatusRepo.Remove(obj);
        }
    }
}
