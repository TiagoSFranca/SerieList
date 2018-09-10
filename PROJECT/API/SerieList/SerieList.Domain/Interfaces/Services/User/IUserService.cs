using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.User
{
    public interface IUserService : IServiceBase<UserModel>
    {
        PagingResultModel<UserModel> Query(IEnumerable<int> idList, IEnumerable<int> idProfileList,
            IEnumerable<int> idUserStatusList, string firstName, string lastName, string email,
            string userName, bool? excluded, bool? associatedExcluded, PagingModel paging);
    }
}
