using SerieList.Application.AppModels.Product;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Product
{
    public interface IProductCategoryAppService : IAppServiceBase<ProductCategoryAppModel>
    {
        PagingResultAppModel<ProductCategoryAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage);
    }
}
