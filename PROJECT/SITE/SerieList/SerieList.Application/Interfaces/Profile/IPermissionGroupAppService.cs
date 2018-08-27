using SerieList.Application.AppModels.Profile;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Profile
{
    public interface IPermissionGroupAppService : IAppServiceBase<PermissionGroupAppModel>
    {
        PagingResultAppModel<PermissionGroupAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage);
    }
}
