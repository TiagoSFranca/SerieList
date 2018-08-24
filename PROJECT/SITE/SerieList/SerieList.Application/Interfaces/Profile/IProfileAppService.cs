using SerieList.Application.AppModels.Profile;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Profile
{
    public interface IProfileAppService : IAppServiceBase<ProfileAppModel>
    {
        IEnumerable<ProfileAppModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
