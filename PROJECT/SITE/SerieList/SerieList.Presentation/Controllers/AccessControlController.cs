using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.User;
using SerieList.Presentation.Models.Post;
using SerieList.Presentation.Extensions;
using SerieList.Application.Interfaces;
using SerieList.Extras.Util.Messages;

namespace SerieList.Presentation.Controllers
{
    [RoutePrefix("api/AccessControl")]
    public class AccessControlController : ControllerBase
    {
        public IAccessControlAppService _acAppService;

        protected AccessControlMessage accessControlMessage;

        public AccessControlController(IAccessControlAppService acAppService)
        {
            _acAppService = acAppService;
            accessControlMessage = new AccessControlMessage();
        }

        [HttpPost]
        [Route("Register")]
        public ResponseSingleResult<UserRegisterModel> Register([FromBody]UserRegisterModel register)
        {
            var response = new ResponseSingleResult<UserRegisterModel>(accessControlMessage.MethodRegister);
            try
            {
                var userMapped = register.MapperToAppModel();
                _acAppService.Register(userMapped);
                response.Success = true;
                response.Message = accessControlMessage.SuccessRegister;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = accessControlMessage.ErrorRegister;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpGet]
        [Route("ConfirmMail")]
        public ResponseSingleResult<string> ConfirmMail([FromUri]string code)
        {
            var response = new ResponseSingleResult<string>(accessControlMessage.MethodConfirmMail);
            try
            {
                _acAppService.ConfirmMail(code);
                response.Success = true;
                response.Message = accessControlMessage.SuccessConfirmMail;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = accessControlMessage.ErrorConfirmMail;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Authenticate")]
        public ResponseSingleResult<string> Authenticate([FromBody]UserLoginModel login)
        {
            var response = new ResponseSingleResult<string>(accessControlMessage.MethodAuthenticate);
            try
            {
                response.Result = _acAppService.Authenticate(login.Login, login.Password, login.KeepConnected);
                response.Success = true;
                response.Message = accessControlMessage.SuccessAuthenticate;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = accessControlMessage.ErrorAuthenticate;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Unauthenticate")]
        public ResponseSingleResult<string> Unautthenticate()
        {
            var response = new ResponseSingleResult<string>(accessControlMessage.MethodUnuthenticate);
            try
            {
                _acAppService.Unauthenticate(GetToken());
                response.Success = true;
                response.Message = accessControlMessage.SuccessUnauthenticate;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = accessControlMessage.ErrorUnauthenticate;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpGet]
        [Route("ForgotPassword")]
        public ResponseSingleResult<string> ForgotPassword([FromUri]string email)
        {
            var response = new ResponseSingleResult<string>(accessControlMessage.MethodForgotPassword);
            try
            {
                _acAppService.ForgotPassword(email);
                response.Success = true;
                response.Message = accessControlMessage.SuccessForgotPassword;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = accessControlMessage.ErrorForgotPassword;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("ResetPassword")]
        public ResponseSingleResult<string> ResetPassword([FromBody]ResetPasswordModel resetModel)
        {
            var response = new ResponseSingleResult<string>(accessControlMessage.MethodResetPassword);
            try
            {
                _acAppService.ResetPassword(resetModel.Token, resetModel.NewPassword, resetModel.ConfirmPassword);
                response.Success = true;
                response.Message = accessControlMessage.SuccessResetPassword;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = accessControlMessage.ErrorResetPassword;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}