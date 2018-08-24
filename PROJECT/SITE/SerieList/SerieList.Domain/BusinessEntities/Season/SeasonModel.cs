using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Season;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;

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
    }
}
