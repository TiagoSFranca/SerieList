using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Product;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Product
{
    public interface IProductTypeService : IServiceBase<ProductTypeModel>
    {
        PagingResultModel<ProductTypeModel> Query(IEnumerable<int> idList, string description, bool? excluded, PagingModel paging);
    }
}
