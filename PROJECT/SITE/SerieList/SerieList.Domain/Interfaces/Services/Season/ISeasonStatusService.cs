using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Season;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Season
{
    public interface ISeasonStatusService : IServiceBase<SeasonStatusModel>
    {
        PagingResultModel<SeasonStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging);
    }
}
