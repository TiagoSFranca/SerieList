using SerieList.Application.AppModels.Episode;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Episode;

namespace SerieList.Application.Extensions.Episode
{
    internal static class EpisodeExtension
    {
        public static EpisodeModel MapperToDomain(this EpisodeAppModel obj)
        {
            return AutoMapper.Mapper.Map<EpisodeModel>(obj);
        }

        public static EpisodeAppModel MapperToAppModel(this EpisodeModel obj)
        {
            return AutoMapper.Mapper.Map<EpisodeAppModel>(obj);
        }

        public static PagingResultAppModel<EpisodeAppModel> MapperToAppModel(this PagingResultModel<EpisodeModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<EpisodeAppModel>>(obj);
        }
    }
}
