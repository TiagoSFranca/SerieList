using SerieList.Application.AppModels.Season;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Season
{
    public interface ISeasonStatusAppService : IAppServiceBase<SeasonStatusAppModel>
    {
        IEnumerable<SeasonStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
