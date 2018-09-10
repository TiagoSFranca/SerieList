using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Episode;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Episode
{
    public interface IEpisodeStatusService : IServiceBase<EpisodeStatusModel>
    {
        PagingResultModel<EpisodeStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging);
    }
}
