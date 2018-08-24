using SerieList.Application.AppModels.Profile;
using SerieList.Domain.Entitites.Profile;

namespace SerieList.Application.Extensions.Profile
{
    internal static class PermissionExtension
    {
        public static PermissionModel MapperToDomain(this PermissionAppModel obj)
        {
            return AutoMapper.Mapper.Map<PermissionModel>(obj);
        }

        public static PermissionAppModel MapperToAppModel(this PermissionModel obj)
        {
            return AutoMapper.Mapper.Map<PermissionAppModel>(obj);
        }
    }
}
