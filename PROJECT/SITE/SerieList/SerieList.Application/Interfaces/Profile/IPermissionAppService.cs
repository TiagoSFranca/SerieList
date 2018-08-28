using SerieList.Application.AppModels.Profile;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Profile
{
    public interface IPermissionAppService : IAppServiceBase<PermissionAppModel>
    {
        PagingResultAppModel<PermissionAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idPermissionTypeList,
            IEnumerable<int> idPermissionGroupList, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage);
    }
}
