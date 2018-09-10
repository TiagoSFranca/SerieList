using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Profile;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
namespace SerieList.Domain.Entitites.Profile
{
    public partial class ProfileModel : IExcluded
    {
        public virtual void ValidateExcluded()
        {
            ProfileServiceMessage psm = new ProfileServiceMessage();
            if (Excluded)
                throw new ServiceException(psm.Excluded);
        }
    }
}
