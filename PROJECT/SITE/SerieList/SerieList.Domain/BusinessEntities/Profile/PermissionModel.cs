using System;
using System.Linq.Expressions;

namespace SerieList.Domain.Entitites.Profile
{
    public partial class PermissionModel
    {
        public static Expression<Func<PermissionModel, bool>> AssociationExcludedExpression(bool excluded)
        {
            Expression<Func<PermissionModel, bool>> ex = u => u.PermissionType.Excluded == excluded 
            && u.PermissionGroup.Excluded == excluded;

            return ex;
        }
    }
}
