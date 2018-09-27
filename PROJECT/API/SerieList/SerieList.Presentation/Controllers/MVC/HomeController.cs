using SerieList.Application.Interfaces;
using System.Web.Mvc;

namespace SerieList.Presentation.Controllers.MVC
{
    public class HomeController : MVCControllerBase
    {
        public HomeController(IAccessControlAppService accessControlAppService)
            : base(accessControlAppService)
        {
        }

        public ActionResult Index()
        {
            ValidToken();

            ViewBag.Title = "Início";
            return View();
        }
    }
}
