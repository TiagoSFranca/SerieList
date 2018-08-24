using SerieList.Domain.Entitites;
using SerieList.Domain.Interfaces.Repositories;

namespace SerieList.Infra.Data.Repositories
{
    public class ConfigurationRepository : RepositoryBase<ConfigurationModel>, IConfigurationRepository
    {
    }
}
