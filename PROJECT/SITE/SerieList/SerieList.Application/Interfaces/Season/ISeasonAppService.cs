using SerieList.Application.AppModels.Season;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Season
{
    public interface ISeasonAppService : IAppServiceBase<SeasonAppModel>
    {
        IEnumerable<SeasonAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductList, IEnumerable<int> idSeasonStatusList,
            IEnumerable<int> idVisibilityList, IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded);
    }
}
