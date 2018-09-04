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
    public class UserSeasonService : ServiceBase<UserSeasonModel>, IUserSeasonService
    {
        private readonly IUserSeasonRepository _userSeasonRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IAccessControlService _accessControlService;

        private UserSeasonServiceMessage userSeasonMessage;

        public UserSeasonService(IUserSeasonRepository userSeasonRepo, ITokenProviderRepository tokenProviderRepo,
            IAccessControlService accessControlService, IConfigurationRepository configurationRepo)
            : base(userSeasonRepo, tokenProviderRepo, configurationRepo)
        {
            _userSeasonRepo = userSeasonRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _accessControlService = accessControlService;
            userSeasonMessage = new UserSeasonServiceMessage();
        }

        public PagingResultModel<UserSeasonModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idSeasonList,
            IEnumerable<int> idUserSeasonStatusList, bool? excluded, bool? associatedExcluded, PagingModel paging)
        {
            var query = _userSeasonRepo.Query();

            if (excluded != null)
                query = query.Where(p => p.Excluded == excluded);

            if (idUserList?.Count() > 0)
                query = query.Where(p => idUserList.Contains(p.IdUser));

            if (idSeasonList?.Count() > 0)
                query = query.Where(p => idSeasonList.Contains(p.IdSeason));

            if (idUserSeasonStatusList?.Count() > 0)
                query = query.Where(p => idUserSeasonStatusList.Contains(p.UserSeasonStatus.IdUserSeasonStatus));

            if (associatedExcluded != null)
            {
                var assocQuery = _userSeasonRepo.AssociationExcluded((bool)associatedExcluded);
                query = query.Where(e => assocQuery.Contains(e));
            }

            return Paginate(query, paging);
        }

        public void Add(UserSeasonModel obj, UserModel userCredentials)
        {
            userCredentials.IsGranted();
            obj.IdUser = userCredentials.IdUser;
            _userSeasonRepo.Add(obj);
        }

        public void Update(UserSeasonModel obj, UserModel userCredentials)
        {
            var userSeason = _userSeasonRepo.GetById(userCredentials.IdUser, obj.IdSeason, true);
            if (userSeason == null)
                throw new ServiceException(userSeasonMessage.NotFound);
            userSeason.ValidateExcluded();
            this.ValidateUser(userCredentials, obj);
            obj.IdUser = userSeason.IdUser;
            _userSeasonRepo.Update(obj);
        }

        public void Remove(UserSeasonModel obj, UserModel userCredentials)
        {
            this.ValidateUser(userCredentials, obj);
            _userSeasonRepo.Remove(obj);
        }

        private void ValidateUser(UserModel userCredentials, UserSeasonModel obj)
        {
            userCredentials.IsGranted();
            var userSeason = _userSeasonRepo.GetById(userCredentials.IdUser, obj.IdSeason, true);
            if (userSeason == null)
                throw new ServiceException(userSeasonMessage.NotFound);
            if (userSeason.IdUser != userCredentials.IdUser && !IsAdmin(userCredentials))
                throw new ServiceException(userSeasonMessage.UserInvalid);
        }

        public UserSeasonModel GetById(int idUser, int idSeason)
        {
            return _userSeasonRepo.GetById(idUser, idSeason);
        }
    }
}
