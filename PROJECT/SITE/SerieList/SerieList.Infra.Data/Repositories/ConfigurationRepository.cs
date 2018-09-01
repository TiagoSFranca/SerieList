using SerieList.Domain.Entitites;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories
{
    public class ConfigurationRepository : RepositoryBase<ConfigurationModel>, IConfigurationRepository
    {
        public ConfigurationRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
