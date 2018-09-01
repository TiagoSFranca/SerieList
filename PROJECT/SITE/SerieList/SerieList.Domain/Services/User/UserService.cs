﻿using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Profile;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Interfaces.Services.User;
using SerieList.Domain.Seed.Profile;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Token;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SerieList.Domain.Services.User
{
    public class UserService : ServiceBase<UserModel>, IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;
        private readonly IPermissionRepository _permissionRepository;

        private readonly IConfigurationService _configService;
        private readonly ITokenProviderService _tokenProviderService;
        private readonly IAccessControlService _accessControlService;

        private UserServiceMessage userMessage;
        private TokenProviderServiceMessage tokenProviderMessage;

        public UserService(IUserRepository UserRepo, IConfigurationService configService,
            ITokenProviderService tokenProviderService, ITokenProviderRepository tokenProviderRepo, IPermissionRepository permisionRepository,
            IAccessControlService accessControlService, IConfigurationRepository configurationRepo)
            : base(UserRepo, tokenProviderRepo, configurationRepo)
        {
            _configService = configService;
            _tokenProviderService = tokenProviderService;
            _userRepo = UserRepo;
            _tokenProviderRepo = tokenProviderRepo;
            _permissionRepository = permisionRepository;
            _accessControlService = accessControlService;
            userMessage = new UserServiceMessage();
            tokenProviderMessage = new TokenProviderServiceMessage();
        }

        public void Update(UserModel obj, UserModel userCredentials)
        {
            var user = _userRepo.GetById(obj.IdUser, true);
            if (user == null)
                throw new ServiceException(userMessage.NotFound);
            user.ValidateExcluded();
            ValidateUser(userCredentials, PermissionSeed.UserUpdate.IdPermission, obj);
            _userRepo.Update(obj);
        }

        public void Remove(UserModel obj, UserModel userCredentials)
        {
            ValidateUser(userCredentials, PermissionSeed.UserRemove.IdPermission, obj);
            _userRepo.Remove(obj);
        }

        public PagingResultModel<UserModel> Query(IEnumerable<int> idList, IEnumerable<int> idProfileList,
            IEnumerable<int> idUserStatusList, string firstName, string lastName, string email,
            string userName, bool? excluded, bool? associatedExcluded, PagingModel paging)
        {
            var query = _userRepo.Query();

            if (excluded != null)
                query = query.Where(pt => pt.Excluded == excluded);

            if (idList?.Count() > 0)
                query = query.Where(pt => idList.Contains(pt.IdUser));

            if (idProfileList?.Count() > 0)
                query = query.Where(pt => idProfileList.Contains(pt.Profile.IdProfile));

            if (idUserStatusList?.Count() > 0)
                query = query.Where(pt => idUserStatusList.Contains(pt.UserStatus.IdUserStatus));

            if (!String.IsNullOrEmpty(firstName))
                query = query.Where(pt => pt.UserInfo.FirstName.ToLower().Contains(firstName.ToLower()));

            if (!String.IsNullOrEmpty(lastName))
                query = query.Where(pt => pt.UserInfo.LastName.ToLower().Contains(lastName.ToLower()));

            if (!String.IsNullOrEmpty(email))
                query = query.Where(pt => pt.UserInfo.Email.ToLower().Contains(email.ToLower()));

            if (!String.IsNullOrEmpty(userName))
                query = query.Where(pt => pt.UserInfo.UserName.ToLower().Contains(userName.ToLower()));

            if (associatedExcluded != null)
            {
                var assocQuery = _userRepo.AssociationExcluded((bool)associatedExcluded);
                query = query.Where(e => assocQuery.Contains(e));
            }

            return Paginate(query, paging);
        }

        private void ValidateUser(UserModel userCredentials, int idPermission, UserModel obj)
        {
            var user = _userRepo.GetById(obj.IdUser, true);
            if (user == null)
                throw new ServiceException(userMessage.NotFound);
            _accessControlService.Authorize(userCredentials, idPermission);
            if (user.IdUser != userCredentials.IdUser && !IsAdmin(userCredentials))
                throw new ServiceException(userMessage.UserInvalid);
        }
    }
}
