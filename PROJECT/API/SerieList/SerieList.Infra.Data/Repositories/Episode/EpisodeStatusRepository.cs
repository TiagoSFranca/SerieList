using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Interfaces.Repositories.Episode;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories.Episode
{
    public class EpisodeStatusRepository : RepositoryBase<EpisodeStatusModel>, IEpisodeStatusRepository
    {
        public EpisodeStatusRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
