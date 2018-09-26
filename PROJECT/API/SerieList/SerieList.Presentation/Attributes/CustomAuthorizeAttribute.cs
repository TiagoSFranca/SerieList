using System;
using System.Web;
using System.Web.Mvc;

namespace SerieList.Presentation.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            // Regra para Autorização: 
            // Um usuário está autorizado se o seu perfil condiz com 
            // um dos perfis autorizado da função, ou se ele for um Admin 
            if (String.IsNullOrEmpty(Roles))
                Roles = "Admin";
            else
                Roles += ", Admin";

            var isAuthorized = base.AuthorizeCore(httpContext);

            return isAuthorized;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/account/login");
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}