using SerieList.Application.AppModels.User;
using SerieList.Application.Interfaces.User;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using SerieList.Application.Extensions.User;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.CommonEntities;
using SerieList.Application.CommonAppModels;

namespace SerieList.Application.Concrete.User
{
    public class UserSeasonAppService : AppServiceBase<UserSeasonModel>, IUserSeasonAppService
    {
        private readonly IUserSeasonService _userSeasonService;
        private readonly ITokenProviderService _tokenProviderService;

        public UserSeasonAppService(IUserSeasonService userSeasonService, ITokenProviderService tokenProviderService)
            : base(userSeasonService, tokenProviderService)
        {
            _userSeasonService = userSeasonService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(UserSeasonAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userSeason = obj.MapperToDomain();
                _userSeasonService.Add(userSeason, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserSeasonAppModel GetById(int id)
        {
            try
            {
                return _userSeasonService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<UserSeasonAppModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idSeasonList,
            IEnumerable<int> idUserSeasonStatusList, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _userSeasonService.Query(idUserList, idSeasonList, idUserSeasonStatusList, excluded, associatedExcluded, paging);
                return result.MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Remove(int id, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userSeason = _userSeasonService.GetById((int)tokenProvider.IdUser, id);
                _userSeasonService.Remove(userSeason, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(UserSeasonAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userSeason = obj.MapperToDomain();
                _userSeasonService.Update(userSeason, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserSeasonAppModel GetById(string token, int idSeason)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                return _userSeasonService.GetById((int)tokenProvider.IdUser, idSeason).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
