using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Linq.Expressions;

namespace SerieList.Domain.Entitites.User
{
    public partial class UserProductModel : IExcluded
    {
        public virtual void ValidateExcluded()
        {
            UserProductServiceMessage usm = new UserProductServiceMessage();
            if (Excluded)
                throw new ServiceException(usm.Excluded);
        }

        public static Expression<Func<UserProductModel, bool>> AssociationExcludedExpression(bool excluded)
        {
            Expression<Func<UserProductModel, bool>> ex = u => u.UserProductStatus.Excluded == excluded;

            return ex;
        }
    }
}
