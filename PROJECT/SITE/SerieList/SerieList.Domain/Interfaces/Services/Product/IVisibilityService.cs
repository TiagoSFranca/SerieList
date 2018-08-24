using SerieList.Domain.Entitites.Product;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Services.Product
{
    public interface IVisibilityService : IServiceBase<VisibilityModel>
    {
        IEnumerable<VisibilityModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
