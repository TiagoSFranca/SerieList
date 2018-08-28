using SerieList.Application.AppModels.Season;
using SerieList.Application.Interfaces.Season;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Season;
using SerieList.Presentation.Extensions;
using SerieList.Presentation.Models.Post;
using SerieList.Presentation.Models.Search.Season;

namespace SerieList.Presentation.Controllers.Season
{
    [RoutePrefix("api/Season")]
    public class SeasonController : ControllerBase
    {
        public ISeasonAppService _sAppService;

        protected SeasonMessage seasonMessage;

        public SeasonController(ISeasonAppService sAppService)
        {
            _sAppService = sAppService;
            seasonMessage = new SeasonMessage();
        }

        public ResponseSingleResult<SeasonAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<SeasonAppModel>(seasonMessage.MethodGet);
            try
            {
                response.Result = _sAppService.GetById(id);
                response.Success = true;
                response.Message = seasonMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = seasonMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<SeasonAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<SeasonAppModel>();
            try
            {
                excluded = _sAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? seasonMessage.MethodReactivate : seasonMessage.MethodDelete;
                _sAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? seasonMessage.SuccessReactivate : seasonMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? seasonMessage.ErrorReactivate : seasonMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<SeasonPostModel> Post([FromBody]SeasonPostModel season)
        {
            bool create = season.IdSeason <= 0;
            var response = new ResponseSingleResult<SeasonPostModel>(create ? seasonMessage.MethodPost : seasonMessage.MethodPut);
            try
            {
                var seasonMapped = season.MapperToAppModel();
                if (create)
                    _sAppService.Add(seasonMapped, GetToken());
                else
                    _sAppService.Update(seasonMapped, GetToken());
                response.Success = true;
                response.Message = create ? seasonMessage.SuccessPost : seasonMessage.SuccessPut;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = create ? seasonMessage.ErrorPost : seasonMessage.ErrorPut;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<SeasonAppModel> Search([FromBody]SeasonSearch filter)
        {
            var response = new ResponseSearchResult<SeasonAppModel>(seasonMessage.MethodGetAll);
            if (filter == null)
                filter = new SeasonSearch();
            try
            {
                var result = _sAppService.Query(filter.IdList, filter.IdProductList, filter.IdSeasonStatusList, filter.IdVisibilityList,
                    filter.IdUserList, filter.Title, filter.Excluded, filter.AssociatedExcluded,
                    filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = seasonMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = seasonMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

    }
}