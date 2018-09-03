using SerieList.Domain.Entitites.User;

namespace SerieList.Domain.Interfaces.Repositories.User
{
    public interface IUserProductRepository : IRepositoryBase<UserProductModel>, IQueryRepository<UserProductModel>
    {
        UserProductModel GetById(int idUser, int idProduct, bool detached = false);
    }
}
