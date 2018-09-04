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
    [RoutePrefix("api/UserEpisodeStatus")]
    public class UserEpisodeStatusController : ControllerBase
    {
        public IUserEpisodeStatusAppService _uesAppService;

        protected UserEpisodeStatusMessage userEpisodeStatusMessage;

        public UserEpisodeStatusController(IUserEpisodeStatusAppService uesAppService)
        {
            _uesAppService = uesAppService;
            userEpisodeStatusMessage = new UserEpisodeStatusMessage();
        }

        public ResponseSingleResult<UserEpisodeStatusAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<UserEpisodeStatusAppModel>(userEpisodeStatusMessage.MethodGet);
            try
            {
                response.Result = _uesAppService.GetById(id);
                response.Success = true;
                response.Message = userEpisodeStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userEpisodeStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<UserEpisodeStatusAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<UserEpisodeStatusAppModel>();
            try
            {
                excluded = excluded = _uesAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? userEpisodeStatusMessage.MethodReactivate : userEpisodeStatusMessage.MethodDelete;
                _uesAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? userEpisodeStatusMessage.SuccessReactivate : userEpisodeStatusMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? userEpisodeStatusMessage.ErrorReactivate : userEpisodeStatusMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<UserEpisodeStatusAppModel> Search([FromBody]UserEpisodeStatusSearch filter)
        {
            var response = new ResponseSearchResult<UserEpisodeStatusAppModel>(userEpisodeStatusMessage.MethodGetAll);
            if (filter == null)
                filter = new UserEpisodeStatusSearch();
            try
            {
                var result = _uesAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = userEpisodeStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userEpisodeStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}