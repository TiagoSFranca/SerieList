using SerieList.Application.AppModels.Season;
using SerieList.Application.Interfaces.Season;
using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Interfaces.Services.Season;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.Extensions.Season;
using SerieList.Domain.Interfaces.Services.Token;

namespace SerieList.Application.Concrete.Season
{
    public class SeasonAppService : AppServiceBase<SeasonModel>, ISeasonAppService
    {
        private readonly ISeasonService _seasonService;
        private readonly ITokenProviderService _tokenProviderService;

        public SeasonAppService(ISeasonService seasonService, ITokenProviderService tokenProviderService)
            : base(seasonService, tokenProviderService)
        {
            _seasonService = seasonService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(SeasonAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var product = obj.MapperToDomain();
                _seasonService.Add(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public SeasonAppModel GetById(int id)
        {
            try
            {
                return _seasonService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public IEnumerable<SeasonAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductList,
            IEnumerable<int> idSeasonStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded)
        {
            try
            {
                return _seasonService.Query(idList, idProductList, idSeasonStatusList, idVisibilityList, idUserList, title, excluded, associatedExcluded)
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
                var product = _seasonService.GetById(id);
                _seasonService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(SeasonAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var product = obj.MapperToDomain();
                _seasonService.Update(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
