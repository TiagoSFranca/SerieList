using SerieList.Application.AppModels.Product;
using SerieList.Application.Interfaces.Product;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Product;
using SerieList.Presentation.Models.Search.Product;
using SerieList.Presentation.Extensions;

namespace SerieList.Presentation.Controllers.Product
{
    [RoutePrefix("api/Visibility")]
    public class VisibilityController : ControllerBase
    {
        public IVisibilityAppService _vAppService;

        protected VisibilityMessage visibilityMessage;

        public VisibilityController(IVisibilityAppService vAppService)
        {
            _vAppService = vAppService;
            visibilityMessage = new VisibilityMessage();
        }

        public ResponseSingleResult<VisibilityAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<VisibilityAppModel>(visibilityMessage.MethodGet);
            try
            {
                response.Result = _vAppService.GetById(id);
                response.Success = true;
                response.Message = visibilityMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = visibilityMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<VisibilityAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<VisibilityAppModel>();
            try
            {
                excluded = _vAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? visibilityMessage.MethodReactivate : visibilityMessage.MethodDelete;
                _vAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? visibilityMessage.SuccessReactivate : visibilityMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? visibilityMessage.ErrorReactivate : visibilityMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<VisibilityAppModel> Search([FromBody]VisibilitySearch filter)
        {
            var response = new ResponseSearchResult<VisibilityAppModel>(visibilityMessage.MethodGetAll);
            if (filter == null)
                filter = new VisibilitySearch();
            try
            {
                var result = _vAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = visibilityMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = visibilityMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}