using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.User
{
    public interface IUserProductAppService : IAppServiceBase<UserProductAppModel>
    {
        PagingResultAppModel<UserProductAppModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idProductList,
            IEnumerable<int> idUserProductStatusList, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage);

        UserProductAppModel GetById(string token, int idProduct);
    }
}
