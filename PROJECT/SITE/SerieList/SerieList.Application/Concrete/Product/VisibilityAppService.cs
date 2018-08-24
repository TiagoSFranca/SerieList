using SerieList.Application.AppModels.Product;
using SerieList.Application.Interfaces.Product;
using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Interfaces.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.Extensions.Product;
using SerieList.Domain.Interfaces.Services.Token;

namespace SerieList.Application.Concrete.Product
{
    public class VisibilityAppService : AppServiceBase<VisibilityModel>, IVisibilityAppService
    {
        private readonly IVisibilityService _visibilityService;
        private readonly ITokenProviderService _tokenProviderService;

        public VisibilityAppService(IVisibilityService visibilityService, ITokenProviderService tokenProviderService)
            : base(visibilityService, tokenProviderService)
        {
            _visibilityService = visibilityService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(VisibilityAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var visibility = obj.MapperToDomain();
                _visibilityService.Add(visibility, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public VisibilityAppModel GetById(int id)
        {
            try
            {
                return _visibilityService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public IEnumerable<VisibilityAppModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            try
            {
                return _visibilityService.Query(idList, description, excluded).Select(e => e.MapperToAppModel()).ToList();
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
                var product = _visibilityService.GetById(id);
                _visibilityService.Remove(product, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(VisibilityAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var visibility = obj.MapperToDomain();
                _visibilityService.Update(visibility, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
