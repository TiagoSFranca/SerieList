using SerieList.Application.AppModels.Profile;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Profile
{
    public interface IPermissionGroupAppService : IAppServiceBase<PermissionGroupAppModel>
    {
        IEnumerable<PermissionGroupAppModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
