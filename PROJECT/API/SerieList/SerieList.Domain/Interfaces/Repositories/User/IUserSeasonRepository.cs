using SerieList.Domain.Entitites.User;

namespace SerieList.Domain.Interfaces.Repositories.User
{
    public interface IUserSeasonRepository : IRepositoryBase<UserSeasonModel>, IQueryRepository<UserSeasonModel>
    {
        UserSeasonModel GetById(int idUser, int idSeason, bool detached = false);
    }
}
