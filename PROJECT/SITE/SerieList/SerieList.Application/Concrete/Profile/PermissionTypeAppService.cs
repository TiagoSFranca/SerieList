using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.Extensions.Profile;
using SerieList.Domain.Entitites.Profile;
using SerieList.Application.Interfaces.Profile;
using SerieList.Domain.Interfaces.Services.Profile;
using SerieList.Application.AppModels.Profile;
using SerieList.Domain.Interfaces.Services.Token;

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

        public IEnumerable<PermissionTypeAppModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            try
            {
                return _permissionTypeService.Query(idList, description, excluded).Select(e => e.MapperToAppModel()).ToList();
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
