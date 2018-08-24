using SerieList.Domain.Entitites.Product;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Product
{
    public interface IProductCategoryService : IServiceBase<ProductCategoryModel>
    {
        IEnumerable<ProductCategoryModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
