using SerieList.Application.AppModels.Season;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Season;

namespace SerieList.Application.Extensions.Season
{
    internal static class SeasonStatusExtension
    {
        public static SeasonStatusModel MapperToDomain(this SeasonStatusAppModel obj)
        {
            return AutoMapper.Mapper.Map<SeasonStatusModel>(obj);
        }

        public static SeasonStatusAppModel MapperToAppModel(this SeasonStatusModel obj)
        {
            return AutoMapper.Mapper.Map<SeasonStatusAppModel>(obj);
        }

        public static PagingResultAppModel<SeasonStatusAppModel> MapperToAppModel(this PagingResultModel<SeasonStatusModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<SeasonStatusAppModel>>(obj);
        }
    }
}
