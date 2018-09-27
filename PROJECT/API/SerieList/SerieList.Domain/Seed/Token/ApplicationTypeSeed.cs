using SerieList.Domain.Entitites.Token;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Token
{
    public class ApplicationTypeSeed
    {
        public static ApplicationTypeModel API { get { return new ApplicationTypeModel() { IdApplicationType = 1, Description = "API", Excluded = false }; } }
        public static ApplicationTypeModel WebSite { get { return new ApplicationTypeModel() { IdApplicationType = 2, Description = "WebSite", Excluded = false }; } }
        public static ApplicationTypeModel App { get { return new ApplicationTypeModel() { IdApplicationType = 3, Description = "App", Excluded = false }; } }

        public static List<ApplicationTypeModel> Seeds
        {
            get
            {
                return new List<ApplicationTypeModel>()
                {
                    API,
                    WebSite,
                    App
                };
            }
        }
    }
}
