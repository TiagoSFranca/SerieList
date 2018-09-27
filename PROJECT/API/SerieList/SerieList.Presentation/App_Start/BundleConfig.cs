using SerieList.Presentation.App_Start.Bundles;
using System.Web.Optimization;

namespace SerieList.Presentation
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundles.RegisterBundles(bundles);
            StyleBundles.RegisterBundles(bundles);
        }
    }
}
