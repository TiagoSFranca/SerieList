using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories.User
{
    public class UserEpisodeStatusRepository : RepositoryBase<UserEpisodeStatusModel>, IUserEpisodeStatusRepository
    {
        public UserEpisodeStatusRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
