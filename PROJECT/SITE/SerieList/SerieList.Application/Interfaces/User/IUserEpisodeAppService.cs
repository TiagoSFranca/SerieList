using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.User
{
    public interface IUserEpisodeAppService : IAppServiceBase<UserEpisodeAppModel>
    {
        PagingResultAppModel<UserEpisodeAppModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idEpisodeList,
            IEnumerable<int> idUserEpisodeStatusList, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage);

        UserEpisodeAppModel GetById(string token, int idEpisode);
    }
}
