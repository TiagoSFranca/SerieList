using SerieList.Application.AppModels.Product;
using SerieList.Application.CommonAppModels;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Product
{
    public interface IVisibilityAppService : IAppServiceBase<VisibilityAppModel>
    {
        PagingResultAppModel<VisibilityAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage);
    }
}
