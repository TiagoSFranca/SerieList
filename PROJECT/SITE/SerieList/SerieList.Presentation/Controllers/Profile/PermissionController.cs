using SerieList.Application.AppModels.Profile;
using SerieList.Application.Interfaces.Profile;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Profile;
using SerieList.Presentation.Models.Search.Profile;

namespace SerieList.Presentation.Controllers.Profile
{
    [RoutePrefix("api/Permission")]
    public class PermissionController : ControllerBase
    {
        public IPermissionAppService _pAppService;

        protected PermissionMessage permissionMessage;

        public PermissionController(IPermissionAppService pAppService)
        {
            _pAppService = pAppService;
            permissionMessage = new PermissionMessage();
        }

        public ResponseSingleResult<PermissionAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<PermissionAppModel>(permissionMessage.MethodGet);
            try
            {
                response.Result = _pAppService.GetById(id);
                response.Success = true;
                response.Message = permissionMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = permissionMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<PermissionAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<PermissionAppModel>();
            try
            {
                excluded = _pAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? permissionMessage.MethodReactivate : permissionMessage.MethodDelete;
                _pAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? permissionMessage.SuccessReactivate : permissionMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? permissionMessage.ErrorReactivate : permissionMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseMultipleResult<PermissionAppModel> Search([FromBody]PermissionSearch filter)
        {
            var response = new ResponseMultipleResult<PermissionAppModel>(permissionMessage.MethodGetAll);
            if (filter == null)
                filter = new PermissionSearch();
            try
            {
                response.Results = _pAppService.Query(filter.IdList, filter.IdPermissionTypeList, filter.IdPermissionGroupList, filter.Excluded, filter.AssociatedExcluded);
                response.Success = true;
                response.Message = permissionMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = permissionMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

    }
}