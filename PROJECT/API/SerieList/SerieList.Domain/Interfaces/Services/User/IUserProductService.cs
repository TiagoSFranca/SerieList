using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.User
{
    public interface IUserProductService : IServiceBase<UserProductModel>
    {
        PagingResultModel<UserProductModel> Query(IEnumerable<int> idUserList, IEnumerable<int> idProductList,
            IEnumerable<int> idUserProductStatusList, bool? excluded, bool? associatedExcluded, PagingModel paging);

        UserProductModel GetById(int idUser, int idProduct);
    }
}
