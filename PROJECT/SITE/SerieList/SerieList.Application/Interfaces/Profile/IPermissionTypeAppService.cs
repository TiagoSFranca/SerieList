using SerieList.Application.AppModels.Profile;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Profile
{
    public interface IPermissionTypeAppService : IAppServiceBase<PermissionTypeAppModel>
    {
        IEnumerable<PermissionTypeAppModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
