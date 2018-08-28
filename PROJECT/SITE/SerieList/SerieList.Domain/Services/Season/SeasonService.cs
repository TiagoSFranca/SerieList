using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Season;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Services.Season;
using SerieList.Domain.Seed.Profile;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Season;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SerieList.Domain.Services.Season
{
    public class SeasonService : ServiceBase<SeasonModel>, ISeasonService
    {
        private readonly ISeasonRepository _seasonRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        private SeasonServiceMessage seasonMessage;

        public SeasonService(ISeasonRepository seasonRepo, ITokenProviderRepository tokenProviderRepo, IAccessControlService accessControlService,
            IConfigurationRepository configurationRepo)
            : base(seasonRepo, tokenProviderRepo, configurationRepo)
        {
            _seasonRepo = seasonRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
            seasonMessage = new SeasonServiceMessage();
        }

        public PagingResultModel<SeasonModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductList,
            IEnumerable<int> idSeasonStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idUserList, 
            string title, bool? excluded, bool? associatedExcluded, PagingModel paging)
        {
            var query = _seasonRepo.Query();

            if (excluded != null)
                query = query.Where(s => s.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(s => idList.Contains(s.IdSeason));

            if (idProductList?.Count() > 0)
                query = query.Where(e => idProductList.Contains(e.IdProduct));

            if (idSeasonStatusList?.Count() > 0)
                query = query.Where(s => idSeasonStatusList.Contains(s.IdSeasonStatus));

            if (idVisibilityList?.Count() > 0)
                query = query.Where(s => idVisibilityList.Contains(s.Visibility.IdVisibility));

            if (idUserList?.Count() > 0)
                query = query.Where(s => idUserList.Contains(s.User.IdUser));

            if (!String.IsNullOrEmpty(title))
                query = query.Where(s => s.Title.ToLower().Contains(title.ToLower()));

            var dataResult = query.ToList();

            if (associatedExcluded != null)
                dataResult = dataResult.Where(s => s.AssociationExcluded((bool)associatedExcluded) != null).ToList();

            return Paginate(dataResult, paging);
        }

        public void Add(SeasonModel obj, UserModel userCredentials)
        {
            _accessControlService.Authorize(userCredentials, PermissionSeed.SeasonAdd.IdPermission);
            obj.IdUser = userCredentials.IdUser;
            _seasonRepo.Add(obj);
        }

        public void Update(SeasonModel obj, UserModel userCredentials)
        {
            var season = _seasonRepo.GetById(obj.IdSeason, true);
            if (season == null)
                throw new ServiceException(seasonMessage.NotFound);
            season.ValidateExcluded();
            ValidateUser(userCredentials, PermissionSeed.SeasonUpdate.IdPermission, obj);
            obj.IdUser = userCredentials.IdUser;
            _seasonRepo.Update(obj);
        }

        public void Remove(SeasonModel obj, UserModel userCredentials)
        {
            ValidateUser(userCredentials, PermissionSeed.SeasonRemove.IdPermission, obj);
            _seasonRepo.Remove(obj);
        }

        private void ValidateUser(UserModel userCredentials, int idPermission, SeasonModel obj)
        {
            var season = _seasonRepo.GetById(obj.IdSeason, true);
            if (season == null)
                throw new ServiceException(seasonMessage.NotFound);
            _accessControlService.Authorize(userCredentials, idPermission);
            bool isAdmin = userCredentials.Profile.Permissions.Any(e => e.IdPermission == PermissionSeed.Admin.IdPermission);
            if (season.IdUser != userCredentials.IdUser && !isAdmin)
                throw new ServiceException(seasonMessage.UserInvalid);
        }
    }
}
