using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Services.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SerieList.Domain.Services.User
{
    public class UserEpisodeService : ServiceBase<UserEpisodeModel>, IUserEpisodeService
    {
        private readonly IUserEpisodeRepository _userEpisodeRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        private UserEpisodeServiceMessage userEpisodeMessage;

        public UserEpisodeService(IUserEpisodeRepository userEpisodeRepo, ITokenProviderRepository tokenProviderRepo,
            IAccessControlService accessControlService, IConfigurationRepository configurationRepo)
            : base(userEpisodeRepo, tokenProviderRepo, configurationRepo)
        {
            _userEpisodeRepo = userEpisodeRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
            userEpisodeMessage = new UserEpisodeServiceMessage();
        }

        public PagingResultModel<UserEpisodeModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idEpisodeList,
            IEnumerable<int> idUserEpisodeStatusList, bool? excluded, bool? associatedExcluded, PagingModel paging)
        {
            var query = _userEpisodeRepo.Query();

            if (excluded != null)
                query = query.Where(p => p.Excluded == excluded);

            if (idUserList?.Count() > 0)
                query = query.Where(p => idUserList.Contains(p.IdUser));

            if (idEpisodeList?.Count() > 0)
                query = query.Where(p => idEpisodeList.Contains(p.IdEpisode));

            if (idUserEpisodeStatusList?.Count() > 0)
                query = query.Where(p => idUserEpisodeStatusList.Contains(p.UserEpisodeStatus.IdUserEpisodeStatus));

            if (associatedExcluded != null)
            {
                var assocQuery = _userEpisodeRepo.AssociationExcluded((bool)associatedExcluded);
                query = query.Where(e => assocQuery.Contains(e));
            }

            return Paginate(query, paging);
        }

        public void Add(UserEpisodeModel obj, UserModel userCredentials)
        {
            userCredentials.IsGranted();
            obj.IdUser = userCredentials.IdUser;
            _userEpisodeRepo.Add(obj);
        }

        public void Update(UserEpisodeModel obj, UserModel userCredentials)
        {
            var userEpisode = _userEpisodeRepo.GetById(userCredentials.IdUser, obj.IdEpisode, true);
            if (userEpisode == null)
                throw new ServiceException(userEpisodeMessage.NotFound);
            userEpisode.ValidateExcluded();
            this.ValidateUser(userCredentials, obj);
            obj.IdUser = userEpisode.IdUser;
            _userEpisodeRepo.Update(obj);
        }

        public void Remove(UserEpisodeModel obj, UserModel userCredentials)
        {
            this.ValidateUser(userCredentials, obj);
            _userEpisodeRepo.Remove(obj);
        }

        private void ValidateUser(UserModel userCredentials, UserEpisodeModel obj)
        {
            userCredentials.IsGranted();
            var userEpisode = _userEpisodeRepo.GetById(userCredentials.IdUser, obj.IdEpisode, true);
            if (userEpisode == null)
                throw new ServiceException(userEpisodeMessage.NotFound);
            if (userEpisode.IdUser != userCredentials.IdUser && !IsAdmin(userCredentials))
                throw new ServiceException(userEpisodeMessage.UserInvalid);
        }

        public UserEpisodeModel GetById(int idUser, int idEpisode)
        {
            return _userEpisodeRepo.GetById(idUser, idEpisode);
        }
    }
}
