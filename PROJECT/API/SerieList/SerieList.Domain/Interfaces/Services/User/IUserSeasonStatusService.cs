using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.User
{
    public interface IUserSeasonStatusService : IServiceBase<UserSeasonStatusModel>
    {
        PagingResultModel<UserSeasonStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging);
    }
}
