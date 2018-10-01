using SerieList.Application.AppModels.Profile;
using SerieList.Application.Interfaces.Profile;
using System;
using System.Web.Http;
using SerieList.Extras.Util;
using SerieList.Extras.Util.Messages.Profile;
using SerieList.Presentation.Extensions;
using SerieList.Presentation.Models.Post;
using SerieList.Presentation.Models.Search.Profile;
using System.Web.Http.Cors;

namespace SerieList.Presentation.Controllers.Profile
{
    [RoutePrefix("api/Profile")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProfileController : APIControllerBase
    {
        public IProfileAppService _pAppService;

        protected ProfileMessage profileMessage;

        public ProfileController(IProfileAppService pAppService)
        {
            _pAppService = pAppService;
            profileMessage = new ProfileMessage();
        }

        public ResponseSingleResult<ProfileAppModel> Get(int id)
        {
            var response = new ResponseSingleResult<ProfileAppModel>(profileMessage.MethodGet);
            try
            {
                response.Result = _pAppService.GetById(id);
                response.Success = true;
                response.Message = profileMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = profileMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<ProfileAppModel> Delete(int id)
        {
            bool? excluded = false;
            var response = new ResponseSingleResult<ProfileAppModel>();
            try
            {
                excluded = _pAppService.GetById(id)?.Excluded;
                response.Method = excluded == true ? profileMessage.MethodReactivate : profileMessage.MethodDelete;
                _pAppService.Remove(id, GetToken());
                response.Success = true;
                response.Message = excluded == true ? profileMessage.SuccessReactivate : profileMessage.SuccessDelete;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = excluded == true ? profileMessage.ErrorReactivate : profileMessage.ErrorDelete;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        public ResponseSingleResult<ProfilePostModel> Post([FromBody]ProfilePostModel profile)
        {
            bool create = profile.IdProfile <= 0;
            var response = new ResponseSingleResult<ProfilePostModel>(create ? profileMessage.MethodPost : profileMessage.MethodPut);
            try
            {
                var ProfileMapped = profile.MapperToAppModel();
                if (create)
                    _pAppService.Add(ProfileMapped, GetToken());
                else
                    _pAppService.Update(ProfileMapped, GetToken());
                response.Success = true;
                response.Message = create ? profileMessage.SuccessPost : profileMessage.SuccessPut;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = create ? profileMessage.ErrorPost : profileMessage.ErrorPut;
                response.Exception = new ResponseException(e);
            }
            return response;
        }

        [HttpPost]
        [Route("Search")]
        public ResponseSearchResult<ProfileAppModel> Search([FromBody]ProfileSearch filter)
        {
            var response = new ResponseSearchResult<ProfileAppModel>(profileMessage.MethodGetAll);
            if (filter == null)
                filter = new ProfileSearch();
            try
            {
                var result = _pAppService.Query(filter.IdList, filter.Description, filter.Excluded, filter.ActualPage, filter.ItemsPerPage);
                response.ResultPaged = result.MapperToView();
                response.Success = true;
                response.Message = profileMessage.SuccessSearch;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = profileMessage.ErrorSearch;
                response.Exception = new ResponseException(e);
            }
            return response;
        }
    }
}