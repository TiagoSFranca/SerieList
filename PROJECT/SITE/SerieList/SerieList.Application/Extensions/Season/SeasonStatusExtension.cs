using SerieList.Application.AppModels.Season;
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
    }
}
