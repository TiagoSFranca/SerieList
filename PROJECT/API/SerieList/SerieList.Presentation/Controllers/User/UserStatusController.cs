using SerieList.Application.AppModels.User;
using SerieList.Application.Interfaces.User;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.User;
using SerieList.Presentation.Models.Search.User;
using SerieList.Presentation.Extensions;

namespace SerieList.Presentation.Controllers.User
{
    [RoutePrefix("api/UserStatus")]
    public class UserStatusController : ControllerBase
    {
        public IUserStatusAppService _usAppService;

        protected UserStatusMessage userStatusMessage;

        public UserStatusController(IUserStatusAppService usAppService)
        {
            _usAppService = usAppService;
            userStatusMessage = new UserStatusMessage();
        }

        public ResponseSingleResult<UserStatusAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<UserStatusAppModel>(userStatusMessage.MethodGet);
            try
            {
                response.Result = _usAppService.GetById(id);
                response.Success = true;
                response.Message = userStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<UserStatusAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<UserStatusAppModel>();
            try
            {
                excluded = excluded = _usAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? userStatusMessage.MethodReactivate : userStatusMessage.MethodDelete;
                _usAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? userStatusMessage.SuccessReactivate : userStatusMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? userStatusMessage.ErrorReactivate : userStatusMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<UserStatusAppModel> Search([FromBody]UserStatusSearch filter)
        {
            var response = new ResponseSearchResult<UserStatusAppModel>(userStatusMessage.MethodGetAll);
            if (filter == null)
                filter = new UserStatusSearch();
            try
            {
                var result = _usAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = userStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}