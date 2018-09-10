using SerieList.Application.AppModels.Episode;
using SerieList.Application.Interfaces.Episode;
using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Interfaces.Services.Episode;
using System;
using System.Collections.Generic;
using SerieList.Application.Extensions.Episode;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.CommonEntities;

namespace SerieList.Application.Concrete.Episode
{
    public class EpisodeStatusAppService : AppServiceBase<EpisodeStatusModel>, IEpisodeStatusAppService
    {
        private readonly IEpisodeStatusService _episodeStatusService;
        private readonly ITokenProviderService _tokenProviderService;

        public EpisodeStatusAppService(IEpisodeStatusService episodeStatusService, ITokenProviderService tokenProviderService)
            : base(episodeStatusService, tokenProviderService)
        {
            _episodeStatusService = episodeStatusService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(EpisodeStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var esMapped = obj.MapperToDomain();
                _episodeStatusService.Add(esMapped, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public EpisodeStatusAppModel GetById(int id)
        {
            try
            {
                return _episodeStatusService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<EpisodeStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _episodeStatusService.Query(idList, description, excluded, paging);
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
                var episodeStatus = _episodeStatusService.GetById(id);
                _episodeStatusService.Remove(episodeStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(EpisodeStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var episodeStatus = obj.MapperToDomain();
                _episodeStatusService.Update(episodeStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
