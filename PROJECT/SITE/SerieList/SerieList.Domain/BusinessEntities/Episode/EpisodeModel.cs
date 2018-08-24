using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Episode;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;

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
    }
}
