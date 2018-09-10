using SerieList.Application.AppModels.Episode;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Episode;

namespace SerieList.Application.Extensions.Episode
{
    internal static class EpisodeStatusExtension
    {
        public static EpisodeStatusModel MapperToDomain(this EpisodeStatusAppModel obj)
        {
            return AutoMapper.Mapper.Map<EpisodeStatusModel>(obj);
        }

        public static EpisodeStatusAppModel MapperToAppModel(this EpisodeStatusModel obj)
        {
            return AutoMapper.Mapper.Map<EpisodeStatusAppModel>(obj);
        }

        public static PagingResultAppModel<EpisodeStatusAppModel> MapperToAppModel(this PagingResultModel<EpisodeStatusModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<EpisodeStatusAppModel>>(obj);
        }
    }
}
