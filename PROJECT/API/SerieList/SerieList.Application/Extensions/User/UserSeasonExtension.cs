using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Extensions.User
{
    internal static class UserSeasonExtension
    {
        public static UserSeasonModel MapperToDomain(this UserSeasonAppModel obj)
        {
            return AutoMapper.Mapper.Map<UserSeasonModel>(obj);
        }

        public static UserSeasonAppModel MapperToAppModel(this UserSeasonModel obj)
        {
            return AutoMapper.Mapper.Map<UserSeasonAppModel>(obj);
        }

        public static PagingResultAppModel<UserSeasonAppModel> MapperToAppModel(this PagingResultModel<UserSeasonModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<UserSeasonAppModel>>(obj);
        }
    }
}
