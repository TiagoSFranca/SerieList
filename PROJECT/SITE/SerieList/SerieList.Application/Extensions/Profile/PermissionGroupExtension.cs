using SerieList.Application.AppModels.Profile;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
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

        public static PagingResultAppModel<PermissionGroupAppModel> MapperToAppModel(this PagingResultModel<PermissionGroupModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<PermissionGroupAppModel>>(obj);
        }
    }
}
