using SerieList.Presentation.Attributes;
using System.Web.Mvc;

namespace SerieList.Presentation.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Início";

            return View();
        }
    }
}
