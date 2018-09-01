using SerieList.Domain.Entitites.Profile;

namespace SerieList.Domain.Interfaces.Repositories.Profile
{
    public interface IPermissionRepository : IRepositoryBase<PermissionModel>, IQueryRepository<PermissionModel>
    {
    }
}
