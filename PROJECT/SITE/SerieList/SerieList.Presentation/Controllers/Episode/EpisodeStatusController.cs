using SerieList.Application.AppModels.Episode;
using SerieList.Application.Interfaces.Episode;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Episode;
using SerieList.Presentation.Models.Search.Episode;

namespace SerieList.Presentation.Controllers.Episode
{
    [RoutePrefix("api/EpisodeStatus")]
    public class EpisodeStatusController : ControllerBase
    {
        public IEpisodeStatusAppService _esAppService;

        protected EpisodeStatusMessage episodeStatusMessage;

        public EpisodeStatusController(IEpisodeStatusAppService esAppService)
        {
            _esAppService = esAppService;
            episodeStatusMessage = new EpisodeStatusMessage();
        }

        public ResponseSingleResult<EpisodeStatusAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<EpisodeStatusAppModel>(episodeStatusMessage.MethodGet);
            try
            {
                response.Result = _esAppService.GetById(id);
                response.Success = true;
                response.Message = episodeStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = episodeStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<EpisodeStatusAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<EpisodeStatusAppModel>();
            try
            {
                excluded = _esAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? episodeStatusMessage.MethodReactivate : episodeStatusMessage.MethodDelete;
                _esAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? episodeStatusMessage.SuccessReactivate : episodeStatusMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? episodeStatusMessage.ErrorReactivate : episodeStatusMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseMultipleResult<EpisodeStatusAppModel> Search([FromBody]EpisodeStatusSearch filter)
        {
            var response = new ResponseMultipleResult<EpisodeStatusAppModel>(episodeStatusMessage.MethodGetAll);
            if (filter == null)
                filter = new EpisodeStatusSearch();
            try
            {
                //response.Results = 
                var p = _esAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.Success = true;
                response.Message = episodeStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = episodeStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}