using SerieList.Application.AppModels.Season;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Season
{
    public interface ISeasonStatusAppService : IAppServiceBase<SeasonStatusAppModel>
    {
        PagingResultAppModel<SeasonStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage);
    }
}
