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
    public class PermissionGroupAppService : AppServiceBase<PermissionGroupModel>, IPermissionGroupAppService
    {
        private readonly IPermissionGroupService _permissionGroupService;
        private readonly ITokenProviderService _tokenProviderService;

        public PermissionGroupAppService(IPermissionGroupService permissionGroupService, ITokenProviderService tokenProviderService)
            : base(permissionGroupService, tokenProviderService)
        {
            _permissionGroupService = permissionGroupService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(PermissionGroupAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var permissionGroup = obj.MapperToDomain();
                _permissionGroupService.Add(permissionGroup, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PermissionGroupAppModel GetById(int id)
        {
            try
            {
                return _permissionGroupService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public PagingResultAppModel<PermissionGroupAppModel> Query(IEnumerable<int> idList, string description, bool? excluded, int actualPage, int itemsPerPage)
        {
            try
            {
                var paging = new PagingModel(actualPage, itemsPerPage);
                var result = _permissionGroupService.Query(idList, description, excluded, paging);
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
                var product = _permissionGroupService.GetById(id);
                _permissionGroupService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(PermissionGroupAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var permissionGroup = obj.MapperToDomain();
                _permissionGroupService.Update(permissionGroup, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
