using SerieList.Application.AppModels.Product;
using SerieList.Application.Interfaces.Product;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Product;
using SerieList.Presentation.Models.Post;
using SerieList.Presentation.Models.Search.Product;
using SerieList.Presentation.Extensions;

namespace SerieList.Presentation.Controllers.Product
{
    [RoutePrefix("api/ProductCategory")]
    public class ProductCategoryController : APIControllerBase
    {
        public IProductCategoryAppService _pcAppService;

        protected ProductCategoryMessage productCategoryMessage;

        public ProductCategoryController(IProductCategoryAppService pcAppService)
        {
            _pcAppService = pcAppService;
            productCategoryMessage = new ProductCategoryMessage();
        }

        public ResponseSingleResult<ProductCategoryAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<ProductCategoryAppModel>(productCategoryMessage.MethodGet);
            try
            {
                response.Result = _pcAppService.GetById(id);
                response.Success = true;
                response.Message = productCategoryMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = productCategoryMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<ProductCategoryAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<ProductCategoryAppModel>();
            try
            {
                response.Method = excluded == true ? productCategoryMessage.MethodReactivate : productCategoryMessage.MethodDelete;
                excluded = _pcAppService.GetById(id)?.Excluded;
                _pcAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? productCategoryMessage.SuccessReactivate : productCategoryMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? productCategoryMessage.ErrorReactivate : productCategoryMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<ProductCategoryAppModel> Post([FromBody]ProductCategoryPostModel productCategory)
        {
            bool create = productCategory.IdProductCategory <= 0;
            var response = new ResponseSingleResult<ProductCategoryAppModel>(create ? productCategoryMessage.MethodPost : productCategoryMessage.MethodPut);
            try
            {
                var productMapped = productCategory.MapperToAppModel();
                if (create)
                    _pcAppService.Add(productMapped, GetToken());
                else
                    _pcAppService.Update(productMapped, GetToken());
                response.Success = true;
                response.Message = create ? productCategoryMessage.SuccessPost : productCategoryMessage.SuccessPut;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = create ? productCategoryMessage.ErrorPost : productCategoryMessage.ErrorPut;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<ProductCategoryAppModel> Search([FromBody]ProductCategorySearch filter)
        {
            var response = new ResponseSearchResult<ProductCategoryAppModel>(productCategoryMessage.MethodGetAll);
            if (filter == null)
                filter = new ProductCategorySearch();
            try
            {
                var result = _pcAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = productCategoryMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = productCategoryMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}