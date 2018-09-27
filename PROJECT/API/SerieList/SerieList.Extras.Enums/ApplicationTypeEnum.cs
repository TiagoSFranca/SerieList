using SerieList.Domain.Seed.Token;

namespace SerieList.Extras.Enums
{
    public class ApplicationTypeEnum
    {
        public static int API { get { return ApplicationTypeSeed.API.IdApplicationType; } }
        public static int WebSite { get { return ApplicationTypeSeed.WebSite.IdApplicationType; } }
        public static int App { get { return ApplicationTypeSeed.App.IdApplicationType; } }
    }
}
