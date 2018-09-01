using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories.User
{
    public class UserProductStatusRepository : RepositoryBase<UserProductStatusModel>, IUserProductStatusRepository
    {
        public UserProductStatusRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
