using SerieList.Application.AppModels.Product;
using SerieList.Application.Interfaces.Product;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Product;
using SerieList.Presentation.Extensions;
using SerieList.Presentation.Models.Post;
using SerieList.Presentation.Models.Search.Product;
using System.Web.Http.Cors;

namespace SerieList.Presentation.Controllers.Product
{
    [RoutePrefix("api/Product")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : APIControllerBase
    {
        public IProductAppService _pAppService;

        protected ProductMessage productMessage;

        public ProductController(IProductAppService pAppService)
        {
            _pAppService = pAppService;
            productMessage = new ProductMessage();
        }

        public ResponseSingleResult<ProductAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<ProductAppModel>(productMessage.MethodGet);
            try
            {
                response.Result = _pAppService.GetById(id);
                response.Success = true;
                response.Message = productMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = productMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<ProductAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<ProductAppModel>();
            try
            {
                excluded = _pAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? productMessage.MethodReactivate : productMessage.MethodDelete;
                _pAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? productMessage.SuccessReactivate : productMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? productMessage.ErrorReactivate : productMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<ProductPostModel> Post([FromBody]ProductPostModel product)
        {
            bool create = product.IdProduct <= 0;
            var response = new ResponseSingleResult<ProductPostModel>(create ? productMessage.MethodPost : productMessage.MethodPut);
            try
            {
                var productMapped = product.MapperToAppModel();
                if (create)
                    _pAppService.Add(productMapped, GetToken());
                else
                    _pAppService.Update(productMapped, GetToken());
                response.Success = true;
                response.Message = create ? productMessage.SuccessPost : productMessage.SuccessPut;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = create ? productMessage.ErrorPost : productMessage.ErrorPut;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<ProductAppModel> Search([FromBody]ProductSearch filter)
        {
            var response = new ResponseSearchResult<ProductAppModel>(productMessage.MethodGetAll);
            if (filter == null)
                filter = new ProductSearch();
            try
            {

                var result = _pAppService.Query(filter.IdList, filter.IdProductTypeList, filter.IdProductStatusList, filter.IdVisibilityList, 
                    filter.IdUserList, filter.Title, filter.Excluded, filter.AssociatedExcluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = productMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = productMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

    }
}