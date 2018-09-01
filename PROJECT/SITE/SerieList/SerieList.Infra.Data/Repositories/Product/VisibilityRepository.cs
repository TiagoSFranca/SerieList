using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Repositories.Product;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories.Product
{
    public class VisibilityRepository : RepositoryBase<VisibilityModel>, IVisibilityRepository
    {
        public VisibilityRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
