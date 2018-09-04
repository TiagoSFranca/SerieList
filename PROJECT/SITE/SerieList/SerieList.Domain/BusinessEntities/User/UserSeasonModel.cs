using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Linq.Expressions;

namespace SerieList.Domain.Entitites.User
{
    public partial class UserSeasonModel : IExcluded
    {
        public virtual void ValidateExcluded()
        {
            UserSeasonServiceMessage usm = new UserSeasonServiceMessage();
            if (Excluded)
                throw new ServiceException(usm.Excluded);
        }

        public static Expression<Func<UserSeasonModel, bool>> AssociationExcludedExpression(bool excluded)
        {
            Expression<Func<UserSeasonModel, bool>> ex = u => u.UserSeasonStatus.Excluded == excluded
            && u.User.Excluded == excluded
            && u.Season.Excluded == excluded;

            return ex;
        }
    }
}
