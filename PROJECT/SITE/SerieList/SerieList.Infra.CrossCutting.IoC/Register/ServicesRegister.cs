using SerieList.Domain.Interfaces.Services.Product;
using SerieList.Domain.Interfaces.Services.Episode;
using SerieList.Domain.Interfaces.Services.Season;
using SerieList.Domain.Interfaces.Services.Profile;
using SerieList.Domain.Services.Product;
using SerieList.Domain.Services.Episode;
using SerieList.Domain.Services.Season;
using SerieList.Domain.Services.Profile;
using SimpleInjector;
using SerieList.Domain.Interfaces.Services.User;
using SerieList.Domain.Services.User;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Services;
using SerieList.Domain.Mail.Interfaces;
using SerieList.Domain.Mail.Services;
using SerieList.Domain.Services.Token;
using SerieList.Domain.Interfaces.Services.Token;

namespace SerieList.Infra.Data.CrossCutting.IoC.Register
{
    public class ServicesRegister
    {
        public static void Register(Container container)
        {
            #region Product

            container.Register<IProductTypeService, ProductTypeService>(Lifestyle.Scoped);
            container.Register<IProductStatusService, ProductStatusService>(Lifestyle.Scoped);
            container.Register<IProductCategoryService, ProductCategoryService>(Lifestyle.Scoped);
            container.Register<IVisibilityService, VisibilityService>(Lifestyle.Scoped);
            container.Register<IProductService, ProductService>(Lifestyle.Scoped);

            #endregion

            #region Season

            container.Register<ISeasonStatusService, SeasonStatusService>(Lifestyle.Scoped);
            container.Register<ISeasonService, SeasonService>(Lifestyle.Scoped);

            #endregion

            #region Season

            container.Register<IEpisodeStatusService, EpisodeStatusService>(Lifestyle.Scoped);
            container.Register<IEpisodeService, EpisodeService>(Lifestyle.Scoped);

            #endregion

            #region Profile

            container.Register<IPermissionGroupService, PermissionGroupService>(Lifestyle.Scoped);
            container.Register<IPermissionTypeService, PermissionTypeService>(Lifestyle.Scoped);
            container.Register<IPermissionService, PermissionService>(Lifestyle.Scoped);
            container.Register<IProfileService, ProfileService>(Lifestyle.Scoped);

            #endregion

            #region User

            container.Register<IUserStatusService, UserStatusService>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IUserProductStatusService, UserProductStatusService>(Lifestyle.Scoped);
            container.Register<IUserProductService, UserProductService>(Lifestyle.Scoped);
            container.Register<IUserEpisodeStatusService, UserEpisodeStatusService>(Lifestyle.Scoped);
            container.Register<IUserEpisodeService, UserEpisodeService>(Lifestyle.Scoped);

            #endregion

            #region Token

            container.Register<ITokenProviderService, TokenProviderService>(Lifestyle.Scoped);

            #endregion

            container.Register<IConfigurationService, ConfigurationService>(Lifestyle.Scoped);
            container.Register<IAccessControlService, AccessControlService>(Lifestyle.Scoped);
            container.Register<IMailService, MailService>(Lifestyle.Scoped);

        }
    }
}
