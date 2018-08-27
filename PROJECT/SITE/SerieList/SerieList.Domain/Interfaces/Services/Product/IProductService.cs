using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Product;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Product
{
    public interface IProductService : IServiceBase<ProductModel>
    {
        PagingResultModel<ProductModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductTypeList,
            IEnumerable<int> idProductStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idUserList, string title, bool? excluded,
            bool? associatedExcluded, PagingModel paging);
    }
}
