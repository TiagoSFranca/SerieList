using SerieList.Application.AppModels.Profile;
using SerieList.Domain.Entitites.Profile;

namespace SerieList.Application.Extensions.Profile
{
    internal static class PermissionTypeExtension
    {
        public static PermissionTypeModel MapperToDomain(this PermissionTypeAppModel obj)
        {
            return AutoMapper.Mapper.Map<PermissionTypeModel>(obj);
        }

        public static PermissionTypeAppModel MapperToAppModel(this PermissionTypeModel obj)
        {
            return AutoMapper.Mapper.Map<PermissionTypeAppModel>(obj);
        }
    }
}
