using SerieList.Application.AppModels.Episode;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Episode
{
    public interface IEpisodeStatusAppService : IAppServiceBase<EpisodeStatusAppModel>
    {
        PagingResultAppModel<EpisodeStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage);
    }
}
