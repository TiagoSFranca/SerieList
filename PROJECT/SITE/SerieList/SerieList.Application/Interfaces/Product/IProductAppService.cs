using SerieList.Application.AppModels.Product;
using System.Collections.Generic;

namespace SerieList.Application.Interfaces.Product
{
    public interface IProductAppService : IAppServiceBase<ProductAppModel>
    {
        IEnumerable<ProductAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idProductTypeList, 
            IEnumerable<int> idProductStatusList, IEnumerable<int> idVisibilityList, IEnumerable<int> idUserList, string title, bool? excluded, bool? associatedExcluded);
    }
}
