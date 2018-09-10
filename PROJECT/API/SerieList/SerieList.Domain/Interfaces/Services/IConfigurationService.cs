using SerieList.Domain.Entitites;

namespace SerieList.Domain.Interfaces.Services
{
    public interface IConfigurationService : IServiceBase<ConfigurationModel>
    {
        ConfigurationModel GetByKey(string key);

        string GetValueByKey(string key);
    }
}
