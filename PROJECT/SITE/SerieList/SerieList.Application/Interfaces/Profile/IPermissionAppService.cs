using SerieList.Application.AppModels.Profile;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Profile
{
    public interface IPermissionAppService : IAppServiceBase<PermissionAppModel>
    {
        IEnumerable<PermissionAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idPermissionTypeList, IEnumerable<int> idPermissionGroupList, bool? excluded, bool? associatedExcluded);
    }
}
