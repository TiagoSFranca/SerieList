using SerieList.Application.Interfaces;
using SerieList.Presentation.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace SerieList.Presentation.Controllers
{
    public class AccountController : MVCControllerBase
    {
        private readonly IAccessControlAppService _accessControlAppService;
        public AccountController(IAccessControlAppService accessControlAppService)
        {
            _accessControlAppService = accessControlAppService;
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.Title = "Entrar";
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.Title = "Entrar";
            if (ModelState.IsValid)
            {
                try
                {
                    var token = _accessControlAppService.Authenticate(model.UserNameOrEmail, model.Password, model.KeepConnected);
                }
                catch (Exception e)
                {
                    ErrorMessage(e.Message);
                    return View(model);
                }
            }

            return View(model);
        }
    }
}