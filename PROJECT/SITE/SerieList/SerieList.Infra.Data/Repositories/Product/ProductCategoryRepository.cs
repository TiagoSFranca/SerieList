using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Repositories.Product;

namespace SerieList.Infra.Data.Repositories.Product
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategoryModel>, IProductCategoryRepository
    {
    }
}
