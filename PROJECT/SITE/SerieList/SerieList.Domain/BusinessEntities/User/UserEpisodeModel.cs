using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Linq.Expressions;

namespace SerieList.Domain.Entitites.User
{
    public partial class UserEpisodeModel : IExcluded
    {
        public virtual void ValidateExcluded()
        {
            UserEpisodeServiceMessage usm = new UserEpisodeServiceMessage();
            if (Excluded)
                throw new ServiceException(usm.Excluded);
        }

        public static Expression<Func<UserEpisodeModel, bool>> AssociationExcludedExpression(bool excluded)
        {
            Expression<Func<UserEpisodeModel, bool>> ex = u => u.UserEpisodeStatus.Excluded == excluded
            && u.User.Excluded == excluded
            && u.Episode.Excluded == excluded;

            return ex;
        }
    }
}
