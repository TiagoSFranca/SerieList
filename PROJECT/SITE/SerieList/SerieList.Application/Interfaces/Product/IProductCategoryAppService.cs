using SerieList.Application.AppModels.Product;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Product
{
    public interface IProductCategoryAppService : IAppServiceBase<ProductCategoryAppModel>
    {
        IEnumerable<ProductCategoryAppModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
