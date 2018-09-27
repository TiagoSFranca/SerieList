using SerieList.Extras.Util.Messages;
using System.Web.Mvc;

namespace SerieList.Presentation.Controllers
{
    public class MVCControllerBase : Controller
    {
        protected AccessControlMessage accessControlMessage;

        public MVCControllerBase()
        {
            accessControlMessage = new AccessControlMessage();
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
    }
}