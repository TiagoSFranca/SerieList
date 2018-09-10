using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Interfaces.Repositories.Season;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories.Season
{
    public class SeasonStatusRepository : RepositoryBase<SeasonStatusModel>, ISeasonStatusRepository
    {
        public SeasonStatusRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
