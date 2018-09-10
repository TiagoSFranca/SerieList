using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Product;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;

namespace SerieList.Domain.Entitites.Product
{
    public partial class ProductCategoryModel : IExcluded
    {
        public virtual void ValidateExcluded()
        {
            ProductServiceMessage pcsm = new ProductServiceMessage();
            if (Excluded)
                throw new ServiceException(pcsm.Excluded);
        }
    }
}
