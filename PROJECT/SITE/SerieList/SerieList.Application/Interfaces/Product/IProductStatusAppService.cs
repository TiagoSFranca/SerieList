using SerieList.Application.AppModels.Product;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Product
{
    public interface IProductStatusAppService : IAppServiceBase<ProductStatusAppModel>
    {
        IEnumerable<ProductStatusAppModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
