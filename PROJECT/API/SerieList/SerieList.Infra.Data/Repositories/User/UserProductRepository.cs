using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories.User;
using System.Collections.Generic;
using System.Linq;
using SerieList.Infra.Data.Data.Context;
using SerieList.Infra.Data.Repositories.Product;
using System.Data.Entity;

namespace SerieList.Infra.Data.Repositories.User
{
    public class UserProductRepository : RepositoryBase<UserProductModel>, IUserProductRepository
    {
        public UserProductRepository(SerieListContext context)
            : base(context)
        {
        }

        public IEnumerable<UserProductModel> AssociationExcluded(bool excluded)
        {
            return AssociationExcluded(excluded, _context);
        }

        public static IEnumerable<UserProductModel> AssociationExcluded(bool excluded, SerieListContext context)
        {
            var query = context.UserProduct.AsQueryable();
            var users = UserRepository.AssociationExcluded(excluded, context);
            var products = ProductRepository.AssociationExcluded(excluded, context);
            query = query.Where(UserProductModel.AssociationExcludedExpression(excluded));
            query = query.Where(e => users.Contains(e.User));
            query = query.Where(e => products.Contains(e.Product));

            return query;
        }

        public UserProductModel GetById(int idUser, int idProduct, bool detached = false)
        {
            var query = this.Query();
            var userProduct = query.FirstOrDefault(e => e.IdUser == idUser && e.IdProduct == idProduct);

            if (userProduct != null && detached)
                _context.Entry(userProduct).State = EntityState.Detached;

            return userProduct;
        }
    }
}
