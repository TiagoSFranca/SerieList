using SerieList.Application.AppModels.Episode;
using SerieList.Application.Interfaces.Episode;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Episode;
using SerieList.Presentation.Extensions;
using SerieList.Presentation.Models.Post;
using SerieList.Presentation.Models.Search.Episode;
using System.Web.Http.Cors;

namespace SerieList.Presentation.Controllers.Episode
{
    [RoutePrefix("api/Episode")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EpisodeController : APIControllerBase
    {
        public IEpisodeAppService _eAppService;

        protected EpisodeMessage episodeMessage;

        public EpisodeController(IEpisodeAppService eAppService)
        {
            _eAppService = eAppService;
            episodeMessage = new EpisodeMessage();
        }

        public ResponseSingleResult<EpisodeAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<EpisodeAppModel>(episodeMessage.MethodGet);
            try
            {
                response.Result = _eAppService.GetById(id);
                response.Success = true;
                response.Message = episodeMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = episodeMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<EpisodeAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<EpisodeAppModel>();
            try
            {
                excluded = _eAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? episodeMessage.MethodReactivate : episodeMessage.MethodDelete;
                _eAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? episodeMessage.SuccessReactivate : episodeMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? episodeMessage.ErrorReactivate : episodeMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<EpisodePostModel> Post([FromBody]EpisodePostModel episode)
        {
            bool create = episode.IdEpisode <= 0;
            var response = new ResponseSingleResult<EpisodePostModel>(create ? episodeMessage.MethodPost : episodeMessage.MethodPut);
            try
            {
                var episodeMapped = episode.MapperToAppModel();
                if (create)
                    _eAppService.Add(episodeMapped, GetToken());
                else
                    _eAppService.Update(episodeMapped, GetToken());
                response.Success = true;
                response.Message = create ? episodeMessage.SuccessPost : episodeMessage.SuccessPut;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = create ? episodeMessage.ErrorPost : episodeMessage.ErrorPut;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<EpisodeAppModel> Search([FromBody]EpisodeSearch filter)
        {
            var response = new ResponseSearchResult<EpisodeAppModel>(episodeMessage.MethodGetAll);
            if (filter == null)
                filter = new EpisodeSearch();
            try
            {
                var result = _eAppService.Query(filter.IdList, filter.IdProductList, filter.IdEpisodeStatusList,
                    filter.IdVisibilityList, filter.IdSeasonList, filter.IdUserList, filter.Title, filter.Excluded, filter.AssociatedExcluded,
                    filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = episodeMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = episodeMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}