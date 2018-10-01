using SerieList.Application.AppModels.User;
using SerieList.Application.Interfaces.User;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.User;
using SerieList.Presentation.Models.Search.User;
using SerieList.Presentation.Extensions;
using System.Web.Http.Cors;

namespace SerieList.Presentation.Controllers.User
{
    [RoutePrefix("api/UserProductStatus")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserProductStatusController : APIControllerBase
    {
        public IUserProductStatusAppService _usAppService;

        protected UserProductStatusMessage userStatusMessage;

        public UserProductStatusController(IUserProductStatusAppService usAppService)
        {
            _usAppService = usAppService;
            userStatusMessage = new UserProductStatusMessage();
        }

        public ResponseSingleResult<UserProductStatusAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<UserProductStatusAppModel>(userStatusMessage.MethodGet);
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

        public ResponseSingleResult<UserProductStatusAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<UserProductStatusAppModel>();
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
        public ResponseSearchResult<UserProductStatusAppModel> Search([FromBody]UserProductStatusSearch filter)
        {
            var response = new ResponseSearchResult<UserProductStatusAppModel>(userStatusMessage.MethodGetAll);
            if (filter == null)
                filter = new UserProductStatusSearch();
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