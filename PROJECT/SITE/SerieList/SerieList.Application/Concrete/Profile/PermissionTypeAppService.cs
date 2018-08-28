using System;
using System.Collections.Generic;
using SerieList.Application.Extensions.Profile;
using SerieList.Domain.Entitites.Profile;
using SerieList.Application.Interfaces.Profile;
using SerieList.Domain.Interfaces.Services.Profile;
using SerieList.Application.AppModels.Profile;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.CommonEntities;
using SerieList.Application.CommonAppModels;

namespace SerieList.Application.Concrete.Profile
{
    public class PermissionTypeAppService : AppServiceBase<PermissionTypeModel>, IPermissionTypeAppService
    {
        private readonly IPermissionTypeService _permissionTypeService;
        private readonly ITokenProviderService _tokenProviderService;

        public PermissionTypeAppService(IPermissionTypeService permissionTypeService, ITokenProviderService tokenProviderService)
            : base(permissionTypeService, tokenProviderService)
        {
            _permissionTypeService = permissionTypeService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(PermissionTypeAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var permissionType = obj.MapperToDomain();
                _permissionTypeService.Add(permissionType, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PermissionTypeAppModel GetById(int id)
        {
            try
            {
                return _permissionTypeService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<PermissionTypeAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _permissionTypeService.Query(idList, description, excluded, paging);
                return result.MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Remove(int id, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var product = _permissionTypeService.GetById(id);
                _permissionTypeService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(PermissionTypeAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var permissionType = obj.MapperToDomain();
                _permissionTypeService.Update(permissionType, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
