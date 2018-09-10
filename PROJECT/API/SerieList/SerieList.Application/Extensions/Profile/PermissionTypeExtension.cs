using SerieList.Application.AppModels.Profile;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
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

        public static PagingResultAppModel<PermissionTypeAppModel> MapperToAppModel(this PagingResultModel<PermissionTypeModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<PermissionTypeAppModel>>(obj);
        }
    }
}
