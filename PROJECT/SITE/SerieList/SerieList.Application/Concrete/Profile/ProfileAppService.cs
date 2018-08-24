using SerieList.Application.AppModels.Profile;
using SerieList.Application.Interfaces.Profile;
using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Interfaces.Services.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using SerieList.Application.Extensions.Profile;
using SerieList.Domain.Interfaces.Services.Token;

namespace SerieList.Application.Concrete.Profile
{
    public class ProfileAppService : AppServiceBase<ProfileModel>, IProfileAppService
    {
        private readonly IProfileService _profileService;
        private readonly ITokenProviderService _tokenProviderService;

        public ProfileAppService(IProfileService ProfileService, ITokenProviderService tokenProviderService)
            : base(ProfileService, tokenProviderService)
        {
            _profileService = ProfileService;
            _tokenProviderService = tokenProviderService;
        }

        public void Add(ProfileAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var profile = obj.MapperToDomain();
                _profileService.Add(profile, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public ProfileAppModel GetById(int id)
        {
            try
            {
                return _profileService.GetById(id).MapperToAppModel();
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public IEnumerable<ProfileAppModel> Query(IEnumerable<int> idList, string description, bool? excluded)
        {
            try
            {
                return _profileService
                    .Query(idList, description, excluded)
                    .Select(e => e.MapperToAppModel()).ToList();
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
                var profile = _profileService.GetById(id);
                _profileService.Remove(profile, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        public void Update(ProfileAppModel obj, string token)
        {
            try
            {
                var tokenProvider = ValidateToken(token);
                var profile = obj.MapperToDomain();
                _profileService.Update(profile, tokenProvider.User);
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }
    }
}
