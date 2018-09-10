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
    public class UserEpisodeStatusAppService : AppServiceBase<UserEpisodeStatusModel>, IUserEpisodeStatusAppService
    {
        private readonly IUserEpisodeStatusService _userEpisodeStatusService;
        private readonly ITokenProviderService _tokenProviderService;

        public UserEpisodeStatusAppService(IUserEpisodeStatusService userEpisodeStatusService, ITokenProviderService tokenProviderService)
            : base(userEpisodeStatusService, tokenProviderService)
        {
            _userEpisodeStatusService = userEpisodeStatusService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(UserEpisodeStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userEpisodeStatus = obj.MapperToDomain();
                _userEpisodeStatusService.Add(userEpisodeStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public UserEpisodeStatusAppModel GetById(int id)
        {
            try
            {
                return _userEpisodeStatusService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<UserEpisodeStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _userEpisodeStatusService.Query(idList, description, excluded, paging);
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
                var userEpisodeStatus = _userEpisodeStatusService.GetById(id);
                _userEpisodeStatusService.Remove(userEpisodeStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(UserEpisodeStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var userEpisodeStatus = obj.MapperToDomain();
                _userEpisodeStatusService.Update(userEpisodeStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
