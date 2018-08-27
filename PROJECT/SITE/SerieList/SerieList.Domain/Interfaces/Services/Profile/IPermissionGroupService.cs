using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Profile
{
    public interface IPermissionGroupService : IServiceBase<PermissionGroupModel>
    {
        PagingResultModel<PermissionGroupModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging);
    }
}
