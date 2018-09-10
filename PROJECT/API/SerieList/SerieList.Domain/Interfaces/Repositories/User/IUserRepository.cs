using SerieList.Domain.Entitites.User;
using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Repositories.User
{
    public interface IUserRepository : IRepositoryBase<UserModel>, IQueryRepository<UserModel>
    {
    }
}
