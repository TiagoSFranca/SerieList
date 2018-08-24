﻿using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Profile
{
    public interface IPermissionService : IServiceBase<PermissionModel>
    {
        IEnumerable<PermissionModel> Query(IEnumerable<int> idList, IEnumerable<int> idPermissionTypeList, IEnumerable<int> idPermissionGroupList, bool? excluded, bool? associatedExcluded);
    }
}
