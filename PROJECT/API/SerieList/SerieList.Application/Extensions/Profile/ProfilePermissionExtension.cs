using SerieList.Application.AppModels.Profile;
using SerieList.Domain.Entitites.Profile;

namespace SerieList.Application.Extensions.Profile
{
    internal static class ProfilePermissionExtension
    {
        public static ProfilePermissionModel MapperToDomain(this ProfilePermissionAppModel obj)
        {
            return AutoMapper.Mapper.Map<ProfilePermissionModel>(obj);
        }

        public static ProfilePermissionAppModel MapperToAppModel(this ProfilePermissionModel obj)
        {
            return AutoMapper.Mapper.Map<ProfilePermissionAppModel>(obj);
        }
    }
}
