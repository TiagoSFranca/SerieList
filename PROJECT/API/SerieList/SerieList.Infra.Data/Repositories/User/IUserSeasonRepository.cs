using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories.User;
using System.Collections.Generic;
using System.Linq;
using SerieList.Infra.Data.Data.Context;
using SerieList.Infra.Data.Repositories.Season;
using System.Data.Entity;

namespace SerieList.Infra.Data.Repositories.User
{
    public class UserSeasonRepository : RepositoryBase<UserSeasonModel>, IUserSeasonRepository
    {
        public UserSeasonRepository(SerieListContext context)
            : base(context)
        {
        }

        public IEnumerable<UserSeasonModel> AssociationExcluded(bool excluded)
        {
            return AssociationExcluded(excluded, _context);
        }

        public static IEnumerable<UserSeasonModel> AssociationExcluded(bool excluded, SerieListContext context)
        {
            var query = context.UserSeason.AsQueryable();
            var users = UserRepository.AssociationExcluded(excluded, context);
            var products = SeasonRepository.AssociationExcluded(excluded, context);
            query = query.Where(UserSeasonModel.AssociationExcludedExpression(excluded));
            query = query.Where(e => users.Contains(e.User));
            query = query.Where(e => products.Contains(e.Season));

            return query;
        }

        public UserSeasonModel GetById(int idUser, int idSeason, bool detached = false)
        {
            var query = this.Query();
            var userSeason = query.FirstOrDefault(e => e.IdUser == idUser && e.IdSeason == idSeason);

            if (userSeason != null && detached)
                _context.Entry(userSeason).State = EntityState.Detached;

            return userSeason;
        }
    }
}
