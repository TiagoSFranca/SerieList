using SerieList.Application.AppModels.User;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.User
{
    public interface IUserStatusAppService : IAppServiceBase<UserStatusAppModel>
    {
        IEnumerable<UserStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
