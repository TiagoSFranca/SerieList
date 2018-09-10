using SerieList.Infra.Data.Data.Context;
using SerieList.Infra.Data.CrossCutting.IoC.Register;
using SimpleInjector;

namespace SerieList.Infra.Data.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<SerieListContext>(Lifestyle.Scoped);

            AppServicesRegister.Register(container);

            ServicesRegister.Register(container);

            RepositoriesRegister.Register(container);

        }

    }
}
