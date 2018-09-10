using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Interfaces.Repositories.Profile;
using SerieList.Infra.Data.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SerieList.Infra.Data.Repositories.Profile
{
    public class PermissionRepository : RepositoryBase<PermissionModel>, IPermissionRepository
    {
        public PermissionRepository(SerieListContext context)
            : base(context)
        {
        }

        public static IEnumerable<PermissionModel> AssociationExcluded(bool excluded, SerieListContext context)
        {
            var query = context.Permission.AsQueryable();
            query = query.Where(PermissionModel.AssociationExcludedExpression(excluded));

            return query;
        }

        public IEnumerable<PermissionModel> AssociationExcluded(bool excluded)
        {
            return AssociationExcluded(excluded, _context);
        }
    }
}