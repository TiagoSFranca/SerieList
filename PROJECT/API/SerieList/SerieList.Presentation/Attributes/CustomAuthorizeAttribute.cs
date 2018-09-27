using SerieList.Presentation.Controllers.MVC;
using System.Web.Mvc;

namespace SerieList.Presentation.Attributes
{
    public class CustomAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies[MVCControllerBase.CookieTokenName]?.Value == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}