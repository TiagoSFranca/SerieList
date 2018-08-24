using SerieList.Domain.Entitites;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services;
using System.Linq;
using SerieList.Domain.Entitites.User;
using System;

namespace SerieList.Domain.Services
{
    public class ConfigurationService : ServiceBase<ConfigurationModel>, IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepo;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        public ConfigurationService(IConfigurationRepository episodeRepo, ITokenProviderRepository tokenProviderRepo)
            : base(episodeRepo, tokenProviderRepo)
        {
            _configurationRepo = episodeRepo;
            _tokenProviderRepo = tokenProviderRepo;
        }

        public ConfigurationModel GetByKey(string key)
        {
            return _configurationRepo.Query().FirstOrDefault(c => c.Key.ToLower().Equals(key.ToLower()));
        }

        public string GetValueByKey(string key)
        {
            var obj = this.GetByKey(key);
            if (obj != null)
                return obj.Value;
            return null;
        }

    }
}
