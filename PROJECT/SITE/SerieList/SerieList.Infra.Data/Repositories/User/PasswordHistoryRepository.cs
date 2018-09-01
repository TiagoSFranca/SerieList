using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories.User
{
    public class PasswordHistoryRepository : RepositoryBase<PasswordHistoryModel>, IPasswordHistoryRepository
    {
        public PasswordHistoryRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
