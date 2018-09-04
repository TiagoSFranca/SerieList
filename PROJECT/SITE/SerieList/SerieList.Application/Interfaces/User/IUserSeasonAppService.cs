using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.User
{
    public interface IUserSeasonAppService : IAppServiceBase<UserSeasonAppModel>
    {
        PagingResultAppModel<UserSeasonAppModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idSeasonList,
            IEnumerable<int> idUserSeasonStatusList, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage);

        UserSeasonAppModel GetById(string token, int idSeason);
    }
}
