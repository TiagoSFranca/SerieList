using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Profile
{
    public interface IPermissionGroupService : IServiceBase<PermissionGroupModel>
    {
        IEnumerable<PermissionGroupModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
