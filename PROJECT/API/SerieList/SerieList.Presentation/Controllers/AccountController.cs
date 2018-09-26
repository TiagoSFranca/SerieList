using System.Web.Mvc;

namespace SerieList.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(string redirectUrl)
        {
            ViewBag.Title = "Entrar";

            return View(redirectUrl);
        }
    }
}