using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Presentation.Models.Post;
using SerieList.Presentation.Extensions;
using SerieList.Application.Interfaces;
using SerieList.Extras.Util.Messages;
using System.Web.Http.Cors;
using SerieList.Application.AppModels.User;

namespace SerieList.Presentation.Controllers
{
    [RoutePrefix("api/AccessControl")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccessControlController : APIControllerBase
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
                _acAppService.Register(userMapped, register.IdApplicationType);
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
        public ResponseSingleResult<UserAuthenticatedModel> Authenticate([FromBody]UserLoginModel login)
        {
            var response = new ResponseSingleResult<UserAuthenticatedModel>(accessControlMessage.MethodAuthenticate);
            try
            {
                var token = _acAppService.Authenticate(login.Login, login.Password, login.KeepConnected, login.ApplicationType);
                var user = _acAppService.GetUserByToken(token);
                response.Result = new UserAuthenticatedModel(token, user);
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
        public ResponseSingleResult<string> ForgotPassword([FromUri]string email, [FromUri]int idApplicationType)
        {
            var response = new ResponseSingleResult<string>(accessControlMessage.MethodForgotPassword);
            try
            {
                _acAppService.ForgotPassword(email, idApplicationType);
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

        [HttpPost]
        [Route("ValidToken")]
        public ResponseSingleResult<ValidTokenModel> ValidToken()
        {
            var response = new ResponseSingleResult<ValidTokenModel>(accessControlMessage.MethodValidToken);
            try
            {
                bool valid = _acAppService.ValidToken(GetToken());
                response.Result = new ValidTokenModel(valid);
                response.Success = true;
                response.Message = accessControlMessage.SuccessValidToken;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = accessControlMessage.ErrorValidToken;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("UserByToken")]
        public ResponseSingleResult<UserAppModel> UserByToken()
        {
            var response = new ResponseSingleResult<UserAppModel>(accessControlMessage.MethodUserByToken);
            try
            {
                response.Result = _acAppService.GetUserByToken(GetToken());
                response.Success = true;
                response.Message = accessControlMessage.SuccessUserByToken;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = accessControlMessage.ErrorUserByToken;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}