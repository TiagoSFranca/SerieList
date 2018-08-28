using SerieList.Application.AppModels.Season;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Season
{
    public interface ISeasonAppService : IAppServiceBase<SeasonAppModel>
    {
        PagingResultAppModel<SeasonAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductList,
               IEnumerable<int> idSeasonStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idUserList, string title,
               bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage);
    }
}
