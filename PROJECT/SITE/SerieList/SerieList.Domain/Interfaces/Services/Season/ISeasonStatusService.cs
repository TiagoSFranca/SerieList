using SerieList.Domain.Entitites.Season;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Season
{
    public interface ISeasonStatusService : IServiceBase<SeasonStatusModel>
    {
        IEnumerable<SeasonStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
