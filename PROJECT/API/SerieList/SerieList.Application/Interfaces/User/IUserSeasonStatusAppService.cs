using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.User
{
    public interface IUserSeasonStatusAppService : IAppServiceBase<UserSeasonStatusAppModel>
    {
        PagingResultAppModel<UserSeasonStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage);
    }
}
