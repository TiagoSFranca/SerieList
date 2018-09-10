using SerieList.Application.AppModels.Profile;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Profile
{
    public interface IPermissionTypeAppService : IAppServiceBase<PermissionTypeAppModel>
    {
        PagingResultAppModel<PermissionTypeAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage);
    }
}
