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
    public class UserEpisodeAppService : AppServiceBase<UserEpisodeModel>, IUserEpisodeAppService
    {
        private readonly IUserEpisodeService _userEpisodeService;
        private readonly ITokenProviderService _tokenProviderService;

        public UserEpisodeAppService(IUserEpisodeService userEpisodeService, ITokenProviderService tokenProviderService)
            : base(userEpisodeService, tokenProviderService)
        {
            _userEpisodeService = userEpisodeService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(UserEpisodeAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userEpisode = obj.MapperToDomain();
                _userEpisodeService.Add(userEpisode, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserEpisodeAppModel GetById(int id)
        {
            try
            {
                return _userEpisodeService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<UserEpisodeAppModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idEpisodeList,
            IEnumerable<int> idUserEpisodeStatusList, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _userEpisodeService.Query(idUserList, idEpisodeList, idUserEpisodeStatusList, excluded, associatedExcluded, paging);
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
                var userEpisode = _userEpisodeService.GetById((int)tokenProvider.IdUser, id);
                _userEpisodeService.Remove(userEpisode, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(UserEpisodeAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userEpisode = obj.MapperToDomain();
                _userEpisodeService.Update(userEpisode, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserEpisodeAppModel GetById(string token, int idEpisode)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                return _userEpisodeService.GetById((int)tokenProvider.IdUser, idEpisode).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
