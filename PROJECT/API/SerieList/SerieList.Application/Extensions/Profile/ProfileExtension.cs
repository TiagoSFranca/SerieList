using SerieList.Application.AppModels.Profile;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Profile;

namespace SerieList.Application.Extensions.Profile
{
    internal static class ProfileExtension
    {
        public static ProfileModel MapperToDomain(this ProfileAppModel obj)
        {
            return AutoMapper.Mapper.Map<ProfileModel>(obj);
        }

        public static ProfileAppModel MapperToAppModel(this ProfileModel obj)
        {
            return AutoMapper.Mapper.Map<ProfileAppModel>(obj);
        }

        public static PagingResultAppModel<ProfileAppModel> MapperToAppModel(this PagingResultModel<ProfileModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<ProfileAppModel>>(obj);
        }
    }
}
