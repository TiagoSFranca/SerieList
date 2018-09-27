using SerieList.Application.Interfaces;
using SerieList.Extras.Enums;
using SerieList.Presentation.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace SerieList.Presentation.Controllers.MVC
{
    public class AccountController : MVCControllerBase
    {

        public AccountController(IAccessControlAppService accessControlAppService)
            : base(accessControlAppService)
        {
        }

        public ActionResult Login(string returnUrl)
        {
            ValidToken(true);
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
                    var token = _accessControlAppService.Authenticate(model.UserNameOrEmail, model.Password, model.KeepConnected, ApplicationTypeEnum.API);
                    AddToken(token);
                    var user = GetUser();
                    string message = string.Format("Bem vindo(a), {0} {1}", user.UserInfo.FirstName, user.UserInfo.LastName);
                    SuccessMessage(message);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    ErrorMessage(e.Message);
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Unauthenticate();
            return RedirectToAction("Login", "Account");
        }
    }
}