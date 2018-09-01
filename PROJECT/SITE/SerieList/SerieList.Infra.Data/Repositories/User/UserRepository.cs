using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Infra.Data.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SerieList.Infra.Data.Repositories.User
{
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(SerieListContext context)
            : base(context)
        {
        }

        public static IEnumerable<UserModel> AssociationExcluded(bool excluded, SerieListContext context)
        {
            var query = context.User.AsQueryable();
            query = query.Where(UserModel.AssociationExcludedExpression(excluded));

            return query;
        }

        public IEnumerable<UserModel> AssociationExcluded(bool excluded)
        {
            return AssociationExcluded(excluded, _context);
        }
    }
}
