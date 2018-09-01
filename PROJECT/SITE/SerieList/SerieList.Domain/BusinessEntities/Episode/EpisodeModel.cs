using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Episode;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Linq.Expressions;

namespace SerieList.Domain.Entitites.Episode
{
    public partial class EpisodeModel : IExcluded
    {
        public virtual void ValidateExcluded()
        {
            EpisodeServiceMessage esm = new EpisodeServiceMessage();
            if (Excluded)
                throw new ServiceException(esm.Excluded);
        }

        public static Expression<Func<EpisodeModel, bool>> AssociationExcludedExpression(bool excluded)
        {
            Expression<Func<EpisodeModel, bool>> ex = u => u.Visibility.Excluded == excluded
                && u.EpisodeStatus.Excluded == excluded
                && u.Product.Excluded == excluded
                && u.Season.Excluded == excluded
                && u.User.Excluded == excluded;

            return ex;
        }
    }
}
