using SerieList.Application.AppModels.Product;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Product
{
    public interface IProductTypeAppService : IAppServiceBase<ProductTypeAppModel>
    {
        IEnumerable<ProductTypeAppModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
