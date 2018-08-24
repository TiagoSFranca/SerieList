using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Interfaces.Repositories.Episode;

namespace SerieList.Infra.Data.Repositories.Episode
{
    public class EpisodeRepository : RepositoryBase<EpisodeModel>, IEpisodeRepository
    {
    }
}
