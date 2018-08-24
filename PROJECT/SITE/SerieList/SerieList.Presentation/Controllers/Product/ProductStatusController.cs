using SerieList.Application.AppModels.Product;
using SerieList.Application.Interfaces.Product;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Product;
using SerieList.Presentation.Models.Search.Product;

namespace SerieList.Presentation.Controllers.Product
{
    [RoutePrefix("api/ProductStatus")]
    public class ProductStatusController : ControllerBase
    {
        public IProductStatusAppService _psAppService;

        protected ProductStatusMessage productStatusMessage;

        public ProductStatusController(IProductStatusAppService psAppService)
        {
            _psAppService = psAppService;
            productStatusMessage = new ProductStatusMessage();
        }

        public ResponseSingleResult<ProductStatusAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<ProductStatusAppModel>(productStatusMessage.MethodGet);
            try
            {
                response.Result = _psAppService.GetById(id);
                response.Success = true;
                response.Message = productStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = productStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<ProductStatusAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<ProductStatusAppModel>();
            try
            {
                excluded = _psAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? productStatusMessage.MethodReactivate : productStatusMessage.MethodDelete;
                _psAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? productStatusMessage.SuccessReactivate : productStatusMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? productStatusMessage.ErrorReactivate : productStatusMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseMultipleResult<ProductStatusAppModel> Search([FromBody]ProductStatusSearch filter)
        {
            var response = new ResponseMultipleResult<ProductStatusAppModel>(productStatusMessage.MethodGetAll);
            if (filter == null)
                filter = new ProductStatusSearch();
            try
            {
                response.Results = _psAppService.Query(filter.IdList, filter.Description, filter.Excluded);
                response.Success = true;
                response.Message = productStatusMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = productStatusMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}