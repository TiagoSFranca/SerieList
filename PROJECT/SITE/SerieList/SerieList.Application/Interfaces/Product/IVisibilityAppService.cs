using SerieList.Application.AppModels.Product;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Product
{
    public interface IVisibilityAppService : IAppServiceBase<VisibilityAppModel>
    {
        IEnumerable<VisibilityAppModel> Query(IEnumerable<int> idList, string description, bool? excluded);
    }
}
