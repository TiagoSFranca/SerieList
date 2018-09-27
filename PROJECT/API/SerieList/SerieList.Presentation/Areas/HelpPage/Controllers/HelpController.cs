using System;
using System.Web.Http;
using System.Web.Mvc;
using SerieList.Presentation.Areas.HelpPage.ModelDescriptions;
using SerieList.Presentation.Areas.HelpPage.Models;
using SerieList.Presentation.Controllers.MVC;
using SerieList.Application.Interfaces;
using SerieList.Presentation.Attributes;

namespace SerieList.Presentation.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    [CustomAuthorize]
    public class HelpController : MVCControllerBase
    {
        private const string ErrorViewName = "Error";

        public HelpController(IAccessControlAppService accessControlAppService)
            : base(accessControlAppService)
        {
            Configuration = GlobalConfiguration.Configuration;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}