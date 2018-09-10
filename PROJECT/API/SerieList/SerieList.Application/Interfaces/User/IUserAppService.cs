using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.User
{
    public interface IUserAppService : IAppServiceBase<UserAppModel>
    {
        PagingResultAppModel<UserAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProfileList,
               IEnumerable<int> idUserStatusList, string firstName, string lastName,
               string email, string userName, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage);
    }
}
