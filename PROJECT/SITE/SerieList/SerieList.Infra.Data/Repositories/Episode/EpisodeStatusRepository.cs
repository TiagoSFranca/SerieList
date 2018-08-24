using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Interfaces.Repositories.Episode;

namespace SerieList.Infra.Data.Repositories.Episode
{
    public class EpisodeStatusRepository : RepositoryBase<EpisodeStatusModel>, IEpisodeStatusRepository
    {
    }
}
