using System;
using System.Web;
using System.Web.Mvc;

namespace SerieList.Presentation.Attributes
{
    public class CustomAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserID"] == null)
            {
                var p = filterContext.HttpContext.Request.Url;
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}