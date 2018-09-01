using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Interfaces.Repositories.Profile;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories.Profile
{
    public class PermissionGroupRepository : RepositoryBase<PermissionGroupModel>, IPermissionGroupRepository
    {
        public PermissionGroupRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
