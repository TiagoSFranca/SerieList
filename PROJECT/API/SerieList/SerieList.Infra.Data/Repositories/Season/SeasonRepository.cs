using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Interfaces.Repositories.Season;
using SerieList.Infra.Data.Data.Context;
using SerieList.Infra.Data.Repositories.Product;
using SerieList.Infra.Data.Repositories.User;
using System.Collections.Generic;
using System.Linq;

namespace SerieList.Infra.Data.Repositories.Season
{
    public class SeasonRepository : RepositoryBase<SeasonModel>, ISeasonRepository
    {
        public SeasonRepository(SerieListContext context)
            : base(context)
        {
        }

        public static IEnumerable<SeasonModel> AssociationExcluded(bool excluded, SerieListContext context)
        {
            var query = context.Season.AsQueryable();
            var users = UserRepository.AssociationExcluded(excluded, context);
            var products = ProductRepository.AssociationExcluded(excluded, context);

            query = query.Where(SeasonModel.AssociationExcludedExpression(excluded));
            query = query.Where(e => users.Contains(e.User));
            query = query.Where(e => products.Contains(e.Product));

            return query;
        }

        public IEnumerable<SeasonModel> AssociationExcluded(bool excluded)
        {
            return AssociationExcluded(excluded, _context);
        }
    }
}
