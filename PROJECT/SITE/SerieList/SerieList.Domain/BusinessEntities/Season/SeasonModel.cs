using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Season;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Linq.Expressions;

namespace SerieList.Domain.Entitites.Season
{
    public partial class SeasonModel : IExcluded
    {
        public virtual void ValidateExcluded()
        {
            SeasonServiceMessage ssm = new SeasonServiceMessage();
            if (Excluded)
                throw new ServiceException(ssm.Excluded);
        }

        public static Expression<Func<SeasonModel, bool>> AssociationExcludedExpression(bool excluded)
        {
            Expression<Func<SeasonModel, bool>> ex = u => u.Visibility.Excluded == excluded
                && u.SeasonStatus.Excluded == excluded
                && u.Product.Excluded == excluded
                && u.User.Excluded == excluded;

            return ex;
        }
    }
}
