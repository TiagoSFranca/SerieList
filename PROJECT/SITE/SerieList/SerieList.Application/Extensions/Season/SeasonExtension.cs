using SerieList.Application.AppModels.Season;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Season;

namespace SerieList.Application.Extensions.Season
{
    internal static class SeasonExtension
    {
        public static SeasonModel MapperToDomain(this SeasonAppModel obj)
        {
            return AutoMapper.Mapper.Map<SeasonModel>(obj);
        }

        public static SeasonAppModel MapperToAppModel(this SeasonModel obj)
        {
            return AutoMapper.Mapper.Map<SeasonAppModel>(obj);
        }

        public static PagingResultAppModel<SeasonAppModel> MapperToAppModel(this PagingResultModel<SeasonModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<SeasonAppModel>>(obj);
        }
    }
}
