using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories.User;

namespace SerieList.Infra.Data.Repositories.User
{
    public class PasswordHistoryRepository : RepositoryBase<PasswordHistoryModel>, IPasswordHistoryRepository
    {
    }
}
