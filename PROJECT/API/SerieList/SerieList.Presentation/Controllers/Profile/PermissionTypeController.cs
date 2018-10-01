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
    [RoutePrefix("api/PermissionType")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PermissionTypeController : APIControllerBase
    {
        public IPermissionTypeAppService _ptAppService;

        protected PermissionTypeMessage permissionTypeMessage;

        public PermissionTypeController(IPermissionTypeAppService ptAppService)
        {
            _ptAppService = ptAppService;
            permissionTypeMessage = new PermissionTypeMessage();
        }

        public ResponseSingleResult<PermissionTypeAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<PermissionTypeAppModel>(permissionTypeMessage.MethodGet);
            try
            {
                response.Result = _ptAppService.GetById(id);
                response.Success = true;
                response.Message = permissionTypeMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = permissionTypeMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<PermissionTypeAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<PermissionTypeAppModel>();
            try
            {
                excluded = _ptAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? permissionTypeMessage.MethodReactivate : permissionTypeMessage.MethodDelete;
                _ptAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? permissionTypeMessage.SuccessReactivate : permissionTypeMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? permissionTypeMessage.ErrorReactivate : permissionTypeMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<PermissionTypeAppModel> Search([FromBody]PermissionTypeSearch filter)
        {
            var response = new ResponseSearchResult<PermissionTypeAppModel>(permissionTypeMessage.MethodGetAll);
            if (filter == null)
                filter = new PermissionTypeSearch();
            try
            {
                var result = _ptAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = permissionTypeMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = permissionTypeMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}