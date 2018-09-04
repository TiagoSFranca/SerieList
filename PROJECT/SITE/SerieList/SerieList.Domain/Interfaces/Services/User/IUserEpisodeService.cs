using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.User
{
    public interface IUserEpisodeService : IServiceBase<UserEpisodeModel>
    {
        PagingResultModel<UserEpisodeModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idEpisodeList,
            IEnumerable<int> idUserEpisodeStatusList, bool? excluded, bool? associatedExcluded, PagingModel paging);

        UserEpisodeModel GetById(int idUser, int idEpisode);
    }
}
