using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Repositories.Product;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories.Product
{
    public class ProductTypeRepository : RepositoryBase<ProductTypeModel>, IProductTypeRepository
    {
        public ProductTypeRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
