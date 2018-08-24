using SerieList.Application.AppModels.Season;
using SerieList.Application.Interfaces.Season;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Season;
using SerieList.Presentation.Models.Search.Season;

namespace SerieList.Presentation.Controllers.Season
{
    [RoutePrefix("api/SeasonStatus")]
    public class SeasonStatusController : ControllerBase
    {
        public ISeasonStatusAppService _ssAppService;

        protected SeasonStatusMessage seasonStatusMessage;

        public SeasonStatusController(ISeasonStatusAppService ssAppService)
        {
            _ssAppService = ssAppService;
            seasonStatusMessage = new SeasonStatusMessage();
        }

        public ResponseSingleResult<SeasonStatusAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<SeasonStatusAppModel>(seasonStatusMessage.MethodGet);
            try
            {
                response.Result = _ssAppService.GetById(id);
                response.Success = true;
                response.Message = seasonStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = seasonStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<SeasonStatusAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<SeasonStatusAppModel>();
            try
            {
                excluded = _ssAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? seasonStatusMessage.MethodReactivate : seasonStatusMessage.MethodDelete;
                _ssAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? seasonStatusMessage.SuccessReactivate : seasonStatusMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? seasonStatusMessage.ErrorReactivate : seasonStatusMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseMultipleResult<SeasonStatusAppModel> Search([FromBody]SeasonStatusSearch filter)
        {
            var response = new ResponseMultipleResult<SeasonStatusAppModel>(seasonStatusMessage.MethodGetAll);
            if (filter == null)
                filter = new SeasonStatusSearch();
            try
            {
                response.Results = _ssAppService.Query(filter.IdList, filter.Description, filter.Excluded);
                response.Success = true;
                response.Message = seasonStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = seasonStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}