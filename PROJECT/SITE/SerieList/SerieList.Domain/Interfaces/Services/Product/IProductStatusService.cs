using SerieList.Domain.Entitites.Product;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Product
{
    public interface IProductStatusService : IServiceBase<ProductStatusModel>
    {
        IEnumerable<ProductStatusModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
