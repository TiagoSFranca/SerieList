using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.User
{
    public interface IUserSeasonService : IServiceBase<UserSeasonModel>
    {
        PagingResultModel<UserSeasonModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idSeasonList,
            IEnumerable<int> idUserSeasonStatusList, bool? excluded, bool? associatedExcluded, PagingModel paging);

        UserSeasonModel GetById(int idUser, int idSeason);
    }
}
