using SerieList.Application.AppModels.User;
using SerieList.Application.Interfaces.User;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.User;
using SerieList.Presentation.Models.Post;
using SerieList.Presentation.Models.Search.User;

namespace SerieList.Presentation.Controllers.User
{
    [RoutePrefix("api/User")]
    public class UserController : ControllerBase
    {
        public IUserAppService _uAppService;

        protected UserMessage userMessage;

        public UserController(IUserAppService eAppService)
        {
            _uAppService = eAppService;
            userMessage = new UserMessage();
        }

        public ResponseSingleResult<UserAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<UserAppModel>(userMessage.MethodGet);
            try
            {
                response.Result = _uAppService.GetById(id);
                response.Success = true;
                response.Message = userMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<UserAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<UserAppModel>();
            try
            {
                excluded = _uAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? userMessage.MethodReactivate : userMessage.MethodDelete;
                _uAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? userMessage.SuccessReactivate : userMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? userMessage.ErrorReactivate : userMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        //public ResponseSingleResult<UserPostModel> Post([FromBody]UserPostModel User)
        //{
        //    bool create = User.IdUser <= 0;
        //    var response = new ResponseSingleResult<UserPostModel>(create ? UserMessage.MethodPost : UserMessage.MethodPut);
        //    try
        //    {
        //        var UserMapped = User.MapperToAppModel();
        //        if (create)
        //            _eAppService.Add(UserMapped);
        //        else
        //            _eAppService.Update(UserMapped);
        //        response.Success = true;
        //        response.Message = create ? UserMessage.SuccessPost : UserMessage.SuccessPut;
        //    }
        //    catch (Exception e)
        //    {
        //        response.Success = false;
        //        response.ErrorMessage = e.Message;
        //        response.Message = create ? UserMessage.ErrorPost : UserMessage.ErrorPut;
        //        response.StackTrace = e.StackTrace;
        //    }
        //    return response;
        //}

        [HttpPost]
        [Route("Search")]
        public ResponseMultipleResult<UserAppModel> Search([FromBody]UserSearch filter)
        {
            var response = new ResponseMultipleResult<UserAppModel>(userMessage.MethodGetAll);
            if (filter == null)
                filter = new UserSearch();
            try
            {
                response.Results = _uAppService.Query(filter.IdList, filter.IdProfileList, filter.IdUserStatusList,
            filter.FirstName, filter.LastName, filter.Email, filter.UserName, filter.Excluded, filter.AssociatedExcluded);
                response.Success = true;
                response.Message = userMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}