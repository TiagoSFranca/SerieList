using SerieList.Application.AppModels.User;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.User
{
    public interface IUserAppService : IAppServiceBase<UserAppModel>
    {
        IEnumerable<UserAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProfileList, IEnumerable<int> idUserStatusList,
            string firstName, string lastName, string email, string userName, bool? excluded, bool? associatedExcluded);
    }
}
