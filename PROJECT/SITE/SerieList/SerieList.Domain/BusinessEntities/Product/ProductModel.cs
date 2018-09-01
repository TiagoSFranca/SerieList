using SerieList.Domain.Interfaces;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Product;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;
using System.Linq.Expressions;

namespace SerieList.Domain.Entitites.Product
{
    public partial class ProductModel : IExcluded
    {
        public virtual void ValidateExcluded()
        {
            ProductServiceMessage pcsm = new ProductServiceMessage();
            if (Excluded)
                throw new ServiceException(pcsm.Excluded);
        }

        public static Expression<Func<ProductModel, bool>> AssociationExcludedExpression(bool excluded)
        {
            Expression<Func<ProductModel, bool>> ex = u => u.Visibility.Excluded == excluded
                && u.ProductStatus.Excluded == excluded
                && u.ProductType.Excluded == excluded
                && u.User.Excluded == excluded;
            return ex;
        }
    }
}
