using SerieList.Infra.Data.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SerieList.Presentation.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void InitializeAPI()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            container.Verify();
        }

        public static void InitializaMVC()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            InitializeContainer(container);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}