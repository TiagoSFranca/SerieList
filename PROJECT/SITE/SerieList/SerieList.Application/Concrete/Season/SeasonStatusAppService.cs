using SerieList.Application.AppModels.Season;
using SerieList.Application.Interfaces.Season;
using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Interfaces.Services.Season;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.Extensions.Season;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Interfaces.Services;

namespace SerieList.Application.Concrete.Season
{
    public class SeasonStatusAppService : AppServiceBase<SeasonStatusModel>, ISeasonStatusAppService
    {
        private readonly ISeasonStatusService _seasonStatusService;
        private readonly ITokenProviderService _tokenProviderService;

        public SeasonStatusAppService(ISeasonStatusService seasonStatusService, ITokenProviderService tokenProviderService,
            IConfigurationService configurationService)
            : base(seasonStatusService, tokenProviderService, configurationService)
        {
            _seasonStatusService = seasonStatusService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(SeasonStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var seasonStatus = obj.MapperToDomain();
                _seasonStatusService.Add(seasonStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public SeasonStatusAppModel GetById(int id)
        {
            try
            {
                return _seasonStatusService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public IEnumerable<SeasonStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            try
            {
                return _seasonStatusService.Query(idList, description, excluded).Select(e => e.MapperToAppModel()).ToList();
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
                var product = _seasonStatusService.GetById(id);
                _seasonStatusService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(SeasonStatusAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var seasonStatus = obj.MapperToDomain();
                _seasonStatusService.Update(seasonStatus, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
