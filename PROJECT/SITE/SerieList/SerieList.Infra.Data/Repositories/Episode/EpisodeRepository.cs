using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Interfaces.Repositories.Episode;
using SerieList.Infra.Data.Data.Context;
using SerieList.Infra.Data.Repositories.Product;
using SerieList.Infra.Data.Repositories.Season;
using SerieList.Infra.Data.Repositories.User;
using System.Collections.Generic;
using System.Linq;

namespace SerieList.Infra.Data.Repositories.Episode
{
    public class EpisodeRepository : RepositoryBase<EpisodeModel>, IEpisodeRepository
    {
        public EpisodeRepository(SerieListContext context)
            : base(context)
        {
        }

        public static IEnumerable<EpisodeModel> AssociationExcluded(bool excluded, SerieListContext context)
        {
            var query = context.Episode.AsQueryable();
            var users = UserRepository.AssociationExcluded(excluded, context);
            var products = ProductRepository.AssociationExcluded(excluded, context);
            var seasons = SeasonRepository.AssociationExcluded(excluded, context);

            query = query.Where(EpisodeModel.AssociationExcludedExpression(excluded));
            query = query.Where(e => users.Contains(e.User));
            query = query.Where(e => products.Contains(e.Product));
            query = query.Where(e => seasons.Contains(e.Season));

            return query;
        }

        public IEnumerable<EpisodeModel> AssociationExcluded(bool excluded)
        {
            return AssociationExcluded(excluded, _context);
        }
    }
}
