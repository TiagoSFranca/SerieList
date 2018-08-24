using SerieList.Domain.Entitites.Season;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Season
{
    public interface ISeasonService : IServiceBase<SeasonModel>
    {
        IEnumerable<SeasonModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductList,
            IEnumerable<int> idSeasonStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded);
    }
}
