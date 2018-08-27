using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Interfaces.Repositories.Episode;
using SerieList.Domain.Interfaces.Repositories.Season;
using SerieList.Domain.Interfaces.Services.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Season;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Interfaces.Services;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Episode;
using SerieList.Domain.Interfaces.Repositories;

namespace SerieList.Domain.Services.Episode
{
    public class EpisodeService : ServiceBase<EpisodeModel>, IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;
        private readonly ISeasonRepository _seasonRepo;

        private readonly IAccessControlService _accessControlService;

        private SeasonServiceMessage seasonMessage;
        private EpisodeServiceMessage episodeMessage;

        public EpisodeService(IEpisodeRepository episodeRepo, ITokenProviderRepository tokenProviderRepo, ISeasonRepository seasonRepo,
            IAccessControlService accessControlService, IConfigurationRepository configurationRepo)
            : base(episodeRepo, tokenProviderRepo, configurationRepo)
        {
            _episodeRepo = episodeRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _seasonRepo = seasonRepo;
            _accessControlService = accessControlService;
            seasonMessage = new SeasonServiceMessage();
            episodeMessage = new EpisodeServiceMessage();
        }

        public IEnumerable<EpisodeModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductList,
            IEnumerable<int> idEpisodeStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idSeasonList,
            IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded)
        {
            var query = _episodeRepo.Query();

            if (excluded != null)
                query = query.Where(e => e.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(e => idList.Contains(e.IdEpisode));

            if (idProductList?.Count() > 0)
                query = query.Where(e => idProductList.Contains(e.IdProduct));

            if (idEpisodeStatusList?.Count() > 0)
                query = query.Where(e => idEpisodeStatusList.Contains(e.IdEpisodeStatus));

            if (idVisibilityList?.Count() > 0)
                query = query.Where(e => idVisibilityList.Contains(e.Visibility.IdVisibility));

            if (idSeasonList?.Count() > 0)
                query = query.Where(e => idSeasonList.Contains(e.Season.IdSeason) && e.Season.Excluded == false);

            if (!String.IsNullOrEmpty(title))
                query = query.Where(e => e.Title.ToLower().Contains(title.ToLower()));

            if (idUserList?.Count() > 0)
                query = query.Where(e => idUserList.Contains(e.User.IdUser));

            var dataResult = query.ToList();

            if (associatedExcluded != null)
                dataResult = dataResult.Where(e => e.AssociationExcluded((bool)associatedExcluded) != null).ToList();

            return dataResult;
        }

        public void Add(EpisodeModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.EpisodeAdd.IdPermission);
            this.ValidateSeason(obj);
            obj.IdUser = userCredentials.IdUser;
            _episodeRepo.Add(obj);
        }

        public void Update(EpisodeModel obj, UserModel userCredentials)
        {
            var episode = _episodeRepo.GetById(obj.IdEpisode, true);
            if (episode == null)
                throw new ServiceException(episodeMessage.NotFound);
            episode.ValidateExcluded();
            ValidateUser(userCredentials, PermissionSeed.EpisodeUpdate.IdPermission, obj);
            this.ValidateSeason(obj);
            obj.IdUser = userCredentials.IdUser;
            _episodeRepo.Update(obj);
        }

        public void Remove(EpisodeModel obj, UserModel userCredentials)
        {
            ValidateUser(userCredentials, PermissionSeed.EpisodeRemove.IdPermission, obj);
            _episodeRepo.Remove(obj);
        }

        private void ValidateSeason(EpisodeModel obj)
        {
            if (obj.IdSeason != null)
            {
                var query = _seasonRepo.Query();
                query = query.Where(e => e.IdSeason == (int)obj.IdSeason && e.IdProduct == e.IdProduct);
                if (query.Count() == 0)
                    throw new ServiceException(seasonMessage.NotInProduct((int)obj.IdProduct));
            }
        }

        private void ValidateUser(UserModel userCredentials, int idPermission, EpisodeModel obj)
        {
            var episode = _episodeRepo.GetById(obj.IdEpisode, true);
            if (episode == null)
                throw new ServiceException(episodeMessage.NotFound);
            _accessControlService.Authorize(userCredentials, idPermission);
            bool isAdmin = userCredentials.Profile.Permissions.Any(e => e.IdPermission == PermissionSeed.Admin.IdPermission);
            if (episode.IdUser != userCredentials.IdUser && !isAdmin)
                throw new ServiceException(episodeMessage.UserInvalid);
        }
    }
}
