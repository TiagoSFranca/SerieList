using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Profile
{
    public interface IProfileService : IServiceBase<ProfileModel>
    {
        IEnumerable<ProfileModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
