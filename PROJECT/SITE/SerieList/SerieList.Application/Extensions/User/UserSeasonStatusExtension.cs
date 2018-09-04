using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Extensions.User
{
    internal static class UserSeasonStatusExtension
    {
        public static UserSeasonStatusModel MapperToDomain(this UserSeasonStatusAppModel obj)
        {
            return AutoMapper.Mapper.Map<UserSeasonStatusModel>(obj);
        }

        public static UserSeasonStatusAppModel MapperToAppModel(this UserSeasonStatusModel obj)
        {
            return AutoMapper.Mapper.Map<UserSeasonStatusAppModel>(obj);
        }

        public static PagingResultAppModel<UserSeasonStatusAppModel> MapperToAppModel(this PagingResultModel<UserSeasonStatusModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<UserSeasonStatusAppModel>>(obj);
        }
    }
}
