using SerieList.Domain.Interfaces.Repositories.Product;
using SerieList.Domain.Interfaces.Repositories.Episode;
using SerieList.Domain.Interfaces.Repositories.Season;
using SerieList.Domain.Interfaces.Repositories.Profile;
using SerieList.Infra.Data.Repositories.Product;
using SerieList.Infra.Data.Repositories.Episode;
using SerieList.Infra.Data.Repositories.Season;
using SerieList.Infra.Data.Repositories.Profile;
using SimpleInjector;
using SerieList.Domain.Interfaces.Repositories.User;
using SerieList.Infra.Data.Repositories.User;
using SerieList.Domain.Interfaces.Repositories;
using SerieList.Infra.Data.Repositories;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Infra.Data.Repositories.Token;

namespace SerieList.Infra.Data.CrossCutting.IoC.Register
{
    public class RepositoriesRegister
    {
        public static void Register(Container container)
        {
            #region Product

            container.Register<IProductTypeRepository, ProductTypeRepository>(Lifestyle.Scoped);
            container.Register<IProductStatusRepository, ProductStatusRepository>(Lifestyle.Scoped);
            container.Register<IProductCategoryRepository, ProductCategoryRepository>(Lifestyle.Scoped);
            container.Register<IVisibilityRepository, VisibilityRepository>(Lifestyle.Scoped);
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Scoped);

            #endregion

            #region Season

            container.Register<ISeasonStatusRepository, SeasonStatusRepository>(Lifestyle.Scoped);
            container.Register<ISeasonRepository, SeasonRepository>(Lifestyle.Scoped);

            #endregion

            #region Episode

            container.Register<IEpisodeStatusRepository, EpisodeStatusRepository>(Lifestyle.Scoped);
            container.Register<IEpisodeRepository, EpisodeRepository>(Lifestyle.Scoped);

            #endregion

            #region Profile

            container.Register<IPermissionGroupRepository, PermissionGroupRepository>(Lifestyle.Scoped);
            container.Register<IPermissionTypeRepository, PermissionTypeRepository>(Lifestyle.Scoped);
            container.Register<IPermissionRepository, PermissionRepository>(Lifestyle.Scoped);
            container.Register<IProfileRepository, ProfileRepository>(Lifestyle.Scoped);

            #endregion

            #region User

            container.Register<IUserStatusRepository, UserStatusRepository>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IPasswordHistoryRepository, PasswordHistoryRepository>(Lifestyle.Scoped);

            #endregion

            #region Token

            container.Register<ITokenProviderRepository, TokenProviderRepository>(Lifestyle.Scoped);

            #endregion

            container.Register<IConfigurationRepository, ConfigurationRepository>(Lifestyle.Scoped);
        }
    }
}
