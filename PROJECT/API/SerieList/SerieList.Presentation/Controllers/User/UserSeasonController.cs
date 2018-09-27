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
    [RoutePrefix("api/UserSeason")]
    public class UserSeasonController : APIControllerBase
    {
        public IUserSeasonAppService _usAppService;

        protected UserSeasonMessage userSeasonMessage;

        public UserSeasonController(IUserSeasonAppService pAppService)
        {
            _usAppService = pAppService;
            userSeasonMessage = new UserSeasonMessage();
        }

        public ResponseSingleResult<UserSeasonAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<UserSeasonAppModel>();
            try
            {
                excluded = _usAppService.GetById(GetToken(), id)?.Excluded;
                response.Method = excluded == true ? userSeasonMessage.MethodReactivate : userSeasonMessage.MethodDelete;
                _usAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? userSeasonMessage.SuccessReactivate : userSeasonMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? userSeasonMessage.ErrorReactivate : userSeasonMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<UserSeasonPostModel> Post([FromBody]UserSeasonPostModel userSeason)
        {
            bool create = _usAppService.GetById(GetToken(), userSeason.IdSeason) == null;
            var response = new ResponseSingleResult<UserSeasonPostModel>(create ? userSeasonMessage.MethodPost : userSeasonMessage.MethodPut);
            try
            {
                var userSeasonMapped = userSeason.MapperToAppModel();
                if (create)
                    _usAppService.Add(userSeasonMapped, GetToken());
                else
                    _usAppService.Update(userSeasonMapped, GetToken());
                response.Success = true;
                response.Message = create ? userSeasonMessage.SuccessPost : userSeasonMessage.SuccessPut;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = create ? userSeasonMessage.ErrorPost : userSeasonMessage.ErrorPut;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<UserSeasonAppModel> Search([FromBody]UserSeasonSearch filter)
        {
            var response = new ResponseSearchResult<UserSeasonAppModel>(userSeasonMessage.MethodGetAll);
            if (filter == null)
                filter = new UserSeasonSearch();
            try
            {

                var result = _usAppService.Query(filter.IdUserList, filter.IdSeasonList, filter.IdUserSeasonStatusList,
                    filter.Excluded, filter.AssociatedExcluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = userSeasonMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userSeasonMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

    }
}