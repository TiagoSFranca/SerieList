using SerieList.Domain.Entitites.Episode;

namespace SerieList.Domain.Interfaces.Repositories.Episode
{
    public interface IEpisodeRepository : IRepositoryBase<EpisodeModel>, IQueryRepository<EpisodeModel>
    {
    }
}
