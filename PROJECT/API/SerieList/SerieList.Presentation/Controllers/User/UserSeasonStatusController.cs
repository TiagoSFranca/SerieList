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
    [RoutePrefix("api/UserSeasonStatus")]
    public class UserSeasonStatusController : ControllerBase
    {
        public IUserSeasonStatusAppService _ussAppService;

        protected UserSeasonStatusMessage userSeasonStatusMessage;

        public UserSeasonStatusController(IUserSeasonStatusAppService uesAppService)
        {
            _ussAppService = uesAppService;
            userSeasonStatusMessage = new UserSeasonStatusMessage();
        }

        public ResponseSingleResult<UserSeasonStatusAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<UserSeasonStatusAppModel>(userSeasonStatusMessage.MethodGet);
            try
            {
                response.Result = _ussAppService.GetById(id);
                response.Success = true;
                response.Message = userSeasonStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userSeasonStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<UserSeasonStatusAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<UserSeasonStatusAppModel>();
            try
            {
                excluded = excluded = _ussAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? userSeasonStatusMessage.MethodReactivate : userSeasonStatusMessage.MethodDelete;
                _ussAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? userSeasonStatusMessage.SuccessReactivate : userSeasonStatusMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? userSeasonStatusMessage.ErrorReactivate : userSeasonStatusMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<UserSeasonStatusAppModel> Search([FromBody]UserSeasonStatusSearch filter)
        {
            var response = new ResponseSearchResult<UserSeasonStatusAppModel>(userSeasonStatusMessage.MethodGetAll);
            if (filter == null)
                filter = new UserSeasonStatusSearch();
            try
            {
                var result = _ussAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = userSeasonStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userSeasonStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}