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
    [RoutePrefix("api/UserProduct")]
    public class UserProductController : ControllerBase
    {
        public IUserProductAppService _pAppService;

        protected UserProductMessage userProductMessage;

        public UserProductController(IUserProductAppService pAppService)
        {
            _pAppService = pAppService;
            userProductMessage = new UserProductMessage();
        }

        //public ResponseSingleResult<UserProductAppModel> Get(int id)
        //{
        //    var response = new ResponseSingleResult<UserProductAppModel>(userProductMessage.MethodGet);
        //    try
        //    {
        //        response.Result = _pAppService.GetById(GetToken(), id);
        //        response.Success = true;
        //        response.Message = userProductMessage.SuccessSearch;
        //    }
        //    catch (Exception e)
        //    {
        //        response.Success = false;
        //        response.Message = userProductMessage.ErrorSearch;
        //        response.Exception = new ResponseException(e);
        //    }
        //    return response;
        //}

        public ResponseSingleResult<UserProductAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<UserProductAppModel>();
            try
            {
                excluded = _pAppService.GetById(GetToken(), id)?.Excluded;
                response.Method = excluded == true ? userProductMessage.MethodReactivate : userProductMessage.MethodDelete;
                _pAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? userProductMessage.SuccessReactivate : userProductMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? userProductMessage.ErrorReactivate : userProductMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<UserProductPostModel> Post([FromBody]UserProductPostModel userProduct)
        {
            bool create = _pAppService.GetById(GetToken(), userProduct.IdProduct) == null;
            var response = new ResponseSingleResult<UserProductPostModel>(create ? userProductMessage.MethodPost : userProductMessage.MethodPut);
            try
            {
                var userProductMapped = userProduct.MapperToAppModel();
                if (create)
                    _pAppService.Add(userProductMapped, GetToken());
                else
                    _pAppService.Update(userProductMapped, GetToken());
                response.Success = true;
                response.Message = create ? userProductMessage.SuccessPost : userProductMessage.SuccessPut;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = create ? userProductMessage.ErrorPost : userProductMessage.ErrorPut;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<UserProductAppModel> Search([FromBody]UserProductSearch filter)
        {
            var response = new ResponseSearchResult<UserProductAppModel>(userProductMessage.MethodGetAll);
            if (filter == null)
                filter = new UserProductSearch();
            try
            {

                var result = _pAppService.Query(filter.IdUserList, filter.IdProductList, filter.IdUserProductStatusList,
                    filter.Excluded, filter.AssociatedExcluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = userProductMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = userProductMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

    }
}