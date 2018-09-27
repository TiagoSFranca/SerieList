using SerieList.Application.Interfaces;
using SerieList.Extras.Util.Messages;
using System;
using System.Web;
using System.Web.Mvc;

namespace SerieList.Presentation.Controllers.MVC
{
    public class MVCControllerBase : Controller
    {
        protected readonly IAccessControlAppService _accessControlAppService;
        protected AccessControlMessage accessControlMessage;

        public static string CookieTokenName { get { return "APIUserToken"; } }

        public MVCControllerBase(IAccessControlAppService accessControlAppService)
        {
            _accessControlAppService = accessControlAppService;
            accessControlMessage = new AccessControlMessage();
        }

        public void AddToken(string token)
        {
            HttpCookie TokenCookie = Response.Cookies[CookieTokenName];
            if (TokenCookie == null)
            {
                TokenCookie = new HttpCookie(CookieTokenName);
                TokenCookie.Value = token;
                Request.Cookies.Add(TokenCookie);
            }
            else
                Response.Cookies[CookieTokenName].Value = token;
        }

        private string GetToken()
        {
            string token = string.Empty;
            try
            {
                var tokenCookie = Request.Cookies[CookieTokenName];
                token = tokenCookie.Value ?? string.Empty;
            }
            catch (Exception)
            {
            }

            return token;
        }

        private void RemoveToken()
        {
            if (Request.Cookies[CookieTokenName] != null)
            {
                HttpCookie myCookie = new HttpCookie(CookieTokenName);
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
        }

        public void SuccessMessage(string message = null)
        {
            TempData["success"] = message ?? accessControlMessage.GenericSuccess;
        }

        public void ErrorMessage(string message = null)
        {
            TempData["error"] = message ?? accessControlMessage.GenericError;
        }

        public void InfoMessage(string message)
        {
            TempData["info"] = message;
        }

        public void WarningMessage(string message)
        {
            TempData["warning"] = message;
        }

        public void ValidToken(bool loginPage = false)
        {
            var valid = _accessControlAppService.ValidToken(GetToken());
            if (!valid && !loginPage)
            {
                RemoveToken();
                System.Web.HttpContext.Current.Response.Redirect("~/Account/Login");
            }
            else if (valid && loginPage)
                System.Web.HttpContext.Current.Response.Redirect("~/Home/Index");
        }

        public void Unauthenticate()
        {
            _accessControlAppService.Unauthenticate(GetToken());
            RemoveToken();
        }
    }
}