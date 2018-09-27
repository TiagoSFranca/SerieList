using SerieList.Application.AppModels.Product;
using SerieList.Application.Interfaces.Product;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Product;
using SerieList.Presentation.Models.Search.Product;
using SerieList.Presentation.Extensions;

namespace SerieList.Presentation.Controllers.ProductType
{
    [RoutePrefix("api/ProductType")]
    public class ProductTypeController : APIControllerBase
    {
        public IProductTypeAppService _ptAppService;

        protected ProductTypeMessage productTypeMessage;

        public ProductTypeController(IProductTypeAppService ptAppService)
        {
            _ptAppService = ptAppService;
            productTypeMessage = new ProductTypeMessage();
        }

        public ResponseSingleResult<ProductTypeAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<ProductTypeAppModel>(productTypeMessage.MethodGet);
            try
            {
                response.Result = _ptAppService.GetById(id);
                response.Success = true;
                response.Message = productTypeMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = productTypeMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<ProductTypeAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<ProductTypeAppModel>();
            try
            {
                excluded = _ptAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? productTypeMessage.MethodReactivate : productTypeMessage.MethodDelete;
                _ptAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? productTypeMessage.SuccessReactivate : productTypeMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? productTypeMessage.ErrorReactivate : productTypeMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<ProductTypeAppModel> Search([FromBody]ProductTypeSearch filter)
        {
            var response = new ResponseSearchResult<ProductTypeAppModel>(productTypeMessage.MethodGetAll);
            if (filter == null)
                filter = new ProductTypeSearch();
            try
            {
                var result = _ptAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = productTypeMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = productTypeMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}
