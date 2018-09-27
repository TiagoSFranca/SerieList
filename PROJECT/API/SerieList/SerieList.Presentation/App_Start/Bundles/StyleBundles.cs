using System.Web.Optimization;

namespace SerieList.Presentation.App_Start.Bundles
{
    public class StyleBundles
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Site/css").Include(
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Toastr/css").Include(
                "~/Content/toastr.min.css"));
        }
    }
}