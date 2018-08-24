using SerieList.Domain.Entitites.Episode;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Episode
{
    public interface IEpisodeService : IServiceBase<EpisodeModel>
    {
        IEnumerable<EpisodeModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductList,
            IEnumerable<int> idEpisodeStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idSeasonList,
            IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded);
    }
}
