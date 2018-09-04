using SerieList.Domain.Entitites.User;

namespace SerieList.Domain.Interfaces.Repositories.User
{
    public interface IUserEpisodeRepository : IRepositoryBase<UserEpisodeModel>, IQueryRepository<UserEpisodeModel>
    {
        UserEpisodeModel GetById(int idUser, int idEpisode, bool detached = false);
    }
}
