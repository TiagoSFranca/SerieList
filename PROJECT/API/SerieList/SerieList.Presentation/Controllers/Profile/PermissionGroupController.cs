using SerieList.Application.AppModels.Profile;
using SerieList.Application.Interfaces.Profile;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Profile;
using SerieList.Presentation.Models.Search.Profile;
using SerieList.Presentation.Extensions;
using System.Web.Http.Cors;

namespace SerieList.Presentation.Controllers.Profile
{
    [RoutePrefix("api/PermissionGroup")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PermissionGroupController : APIControllerBase
    {
        public IPermissionGroupAppService _pgAppService;

        protected PermissionGroupMessage permissionGroupMessage;

        public PermissionGroupController(IPermissionGroupAppService pgAppService)
        {
            _pgAppService = pgAppService;
            permissionGroupMessage = new PermissionGroupMessage();
        }

        public ResponseSingleResult<PermissionGroupAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<PermissionGroupAppModel>(permissionGroupMessage.MethodGet);
            try
            {
                response.Result = _pgAppService.GetById(id);
                response.Success = true;
                response.Message = permissionGroupMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = permissionGroupMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<PermissionGroupAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<PermissionGroupAppModel>();
            try
            {
                excluded = _pgAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? permissionGroupMessage.MethodReactivate : permissionGroupMessage.MethodDelete;
                _pgAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? permissionGroupMessage.SuccessReactivate : permissionGroupMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? permissionGroupMessage.ErrorReactivate : permissionGroupMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<PermissionGroupAppModel> Search([FromBody]PermissionGroupSearch filter)
        {
            var response = new ResponseSearchResult<PermissionGroupAppModel>(permissionGroupMessage.MethodGetAll);
            if (filter == null)
                filter = new PermissionGroupSearch();
            try
            {
                var result = _pgAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = permissionGroupMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = permissionGroupMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}