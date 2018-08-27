using SerieList.Application.AppModels.Product;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Product
{
    public interface IProductTypeAppService : IAppServiceBase<ProductTypeAppModel>
    {
        PagingResultAppModel<ProductTypeAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage);
    }
}
