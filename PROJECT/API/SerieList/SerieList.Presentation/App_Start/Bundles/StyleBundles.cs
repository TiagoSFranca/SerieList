using System.Web.Optimization;

namespace SerieList.Presentation.App_Start.Bundles
{
    public class StyleBundles
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Site/css").Include(
                "~/Content/materialize.min.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Toastr/css").Include(
                "~/Content/toastr.min.css"));
        }
    }
}