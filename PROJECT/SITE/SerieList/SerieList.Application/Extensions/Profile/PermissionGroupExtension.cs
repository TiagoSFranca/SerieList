using SerieList.Application.AppModels.Profile;
using SerieList.Domain.Entitites.Profile;

namespace SerieList.Application.Extensions.Profile
{
    internal static class PermissionGroupExtension
    {
        public static PermissionGroupModel MapperToDomain(this PermissionGroupAppModel obj)
        {
            return AutoMapper.Mapper.Map<PermissionGroupModel>(obj);
        }

        public static PermissionGroupAppModel MapperToAppModel(this PermissionGroupModel obj)
        {
            return AutoMapper.Mapper.Map<PermissionGroupAppModel>(obj);
        }
    }
}
