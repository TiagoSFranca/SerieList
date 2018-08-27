﻿using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.Extensions.Episode;
using SerieList.Application.Interfaces.Episode;
using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Interfaces.Services.Episode;
using SerieList.Application.AppModels.Episode;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Interfaces.Services;

namespace SerieList.Application.Concrete.Episode
{
    public class EpisodeAppService : AppServiceBase<EpisodeModel>, IEpisodeAppService
    {
        private readonly IEpisodeService _episodeService;
        private readonly ITokenProviderService _tokenProviderService;

        public EpisodeAppService(IEpisodeService episodeService, ITokenProviderService tokenProviderService,
            IConfigurationService configurationService)
            : base(episodeService, tokenProviderService, configurationService)
        {
            _episodeService = episodeService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(EpisodeAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var product = obj.MapperToDomain();
                _episodeService.Add(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public EpisodeAppModel GetById(int id)
        {
            try
            {
                return _episodeService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public IEnumerable<EpisodeAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductList,
            IEnumerable<int> idEpisodeStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idSeasonList,
            IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded)
        {
            try
            {
                return _episodeService.Query(idList, idProductList, idEpisodeStatusList, idVisibilityList, idSeasonList, idUserList, title, excluded, associatedExcluded)
                    .Select(e => e.MapperToAppModel()).ToList();
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
                var episode = _episodeService.GetById(id);
                _episodeService.Remove(episode, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(EpisodeAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var product = obj.MapperToDomain();
                _episodeService.Update(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
