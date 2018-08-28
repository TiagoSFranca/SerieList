using SerieList.Application.AppModels.Profile;
using SerieList.Application.Interfaces.Profile;
using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Interfaces.Services.Profile;
using System;
using System.Collections.Generic;
using SerieList.Application.Extensions.Profile;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;

namespace SerieList.Application.Concrete.Profile
{
    public class PermissionAppService : AppServiceBase<PermissionModel>, IPermissionAppService
    {
        private readonly IPermissionService _permissionService;
        private readonly ITokenProviderService _tokenProviderService;

        public PermissionAppService(IPermissionService permissionService, ITokenProviderService tokenProviderService)
            : base(permissionService, tokenProviderService)
        {
            _permissionService = permissionService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(PermissionAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var permission = obj.MapperToDomain();
                _permissionService.Add(permission, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PermissionAppModel GetById(int id)
        {
            try
            {
                return _permissionService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<PermissionAppModel> Query(IEnumerable<int> idList, IEnumerable<int> idPermissionTypeList,
            IEnumerable<int> idPermissionGroupList, bool? excluded, bool? associatedExcluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _permissionService.Query(idList, idPermissionTypeList, idPermissionGroupList, excluded, associatedExcluded, paging);
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
                var product = _permissionService.GetById(id);
                _permissionService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(PermissionAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var permission = obj.MapperToDomain();
                _permissionService.Update(permission, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
