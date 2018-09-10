using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SerieList.Presentation.Controllers
{
    public class ControllerBase : ApiController
    {
        protected string GetToken()
        {
            string token = string.Empty;
            var request = Request;
            var headers = request.Headers;
            if (headers.Contains("token"))
                token = headers.GetValues("token").First();
            return token;
        }
    }
}