using SerieList.Application.Concrete.Product;
using SerieList.Application.Concrete.Episode;
using SerieList.Application.Concrete.Season;
using SerieList.Application.Concrete.Profile;
using SerieList.Application.Interfaces.Product;
using SerieList.Application.Interfaces.Episode;
using SerieList.Application.Interfaces.Season;
using SerieList.Application.Interfaces.Profile;
using SimpleInjector;
using SerieList.Application.Concrete.User;
using SerieList.Application.Interfaces.User;
using SerieList.Application.Mail.Interfaces;
using SerieList.Application.Mail.MailTemplate;
using SerieList.Application.Interfaces;
using SerieList.Application.Concrete;

namespace SerieList.Infra.Data.CrossCutting.IoC.Register
{
    public class AppServicesRegister
    {
        public static void Register(Container container)
        {
            #region Product

            container.Register<IProductTypeAppService, ProductTypeAppService>(Lifestyle.Scoped);
            container.Register<IProductStatusAppService, ProductStatusAppService>(Lifestyle.Scoped);
            container.Register<IProductCategoryAppService, ProductCategoryAppService>(Lifestyle.Scoped);
            container.Register<IVisibilityAppService, VisibilityAppService>(Lifestyle.Scoped);
            container.Register<IProductAppService, ProductAppService>(Lifestyle.Scoped);

            #endregion

            #region Season

            container.Register<ISeasonStatusAppService, SeasonStatusAppService>(Lifestyle.Scoped);
            container.Register<ISeasonAppService, SeasonAppService>(Lifestyle.Scoped);

            #endregion

            #region Episode

            container.Register<IEpisodeStatusAppService, EpisodeStatusAppService>(Lifestyle.Scoped);
            container.Register<IEpisodeAppService, EpisodeAppService>(Lifestyle.Scoped);

            #endregion

            #region Profile

            container.Register<IPermissionGroupAppService, PermissionGroupAppService>(Lifestyle.Scoped);
            container.Register<IPermissionTypeAppService, PermissionTypeAppService>(Lifestyle.Scoped);
            container.Register<IPermissionAppService, PermissionAppService>(Lifestyle.Scoped);
            container.Register<IProfileAppService, ProfileAppService>(Lifestyle.Scoped);

            #endregion

            #region User

            container.Register<IUserStatusAppService, UserStatusAppService>(Lifestyle.Scoped);
            container.Register<IUserAppService, UserAppService>(Lifestyle.Scoped);
            container.Register<IUserProductStatusAppService, UserProductStatusAppService>(Lifestyle.Scoped);
            container.Register<IUserProductAppService, UserProductAppService>(Lifestyle.Scoped);

            #endregion

            container.Register<IMailTemplate, MailTemplate>(Lifestyle.Scoped);
            container.Register<IAccessControlAppService, AccessControlAppService>(Lifestyle.Scoped);
        }
    }
}
