using SerieList.Application.AppModels.User;
using SerieList.Application.Interfaces.User;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.User;
using SerieList.Presentation.Extensions;
using SerieList.Presentation.Models.Post;
using SerieList.Presentation.Models.Search.User;

namespace SerieList.Presentation.Controllers.User
{
    [RoutePrefix("api/UserEpisode")]
    public class UserEpisodeController : APIControllerBase
    {
        public IUserEpisodeAppService _ueAppService;

        protected UserEpisodeMessage userEpisodeMessage;

        public UserEpisodeController(IUserEpisodeAppService pAppService)
        {
            _ueAppService = pAppService;
            userEpisodeMessage = new UserEpisodeMessage();
        }

        public ResponseSingleResult<UserEpisodeAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<UserEpisodeAppModel>();
            try
            {
                excluded = _ueAppService.GetById(GetToken(), id)?.Excluded;
                response.Method = excluded == true ? userEpisodeMessage.MethodReactivate : userEpisodeMessage.MethodDelete;
                _ueAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? userEpisodeMessage.SuccessReactivate : userEpisodeMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? userEpisodeMessage.ErrorReactivate : userEpisodeMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<UserEpisodePostModel> Post([FromBody]UserEpisodePostModel userEpisode)
        {
            bool create = _ueAppService.GetById(GetToken(), userEpisode.IdEpisode) == null;
            var response = new ResponseSingleResult<UserEpisodePostModel>(create ? userEpisodeMessage.MethodPost : userEpisodeMessage.MethodPut);
            try
            {
                var userEpisodeMapped = userEpisode.MapperToAppModel();
                if (create)
                    _ueAppService.Add(userEpisodeMapped, GetToken());
                else
                    _ueAppService.Update(userEpisodeMapped, GetToken());
                response.Success = true;
                response.Message = create ? userEpisodeMessage.SuccessPost : userEpisodeMessage.SuccessPut;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = create ? userEpisodeMessage.ErrorPost : userEpisodeMessage.ErrorPut;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<UserEpisodeAppModel> Search([FromBody]UserEpisodeSearch filter)
        {
            var response = new ResponseSearchResult<UserEpisodeAppModel>(userEpisodeMessage.MethodGetAll);
            if (filter == null)
                filter = new UserEpisodeSearch();
            try
            {

                var result = _ueAppService.Query(filter.IdUserList, filter.IdEpisodeList, filter.IdUserEpisodeStatusList,
                    filter.Excluded, filter.AssociatedExcluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = userEpisodeMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userEpisodeMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

    }
}