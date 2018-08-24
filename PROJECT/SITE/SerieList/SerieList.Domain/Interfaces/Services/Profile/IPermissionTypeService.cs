using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Profile
{
    public interface IPermissionTypeService : IServiceBase<PermissionTypeModel>
    {
        IEnumerable<PermissionTypeModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
