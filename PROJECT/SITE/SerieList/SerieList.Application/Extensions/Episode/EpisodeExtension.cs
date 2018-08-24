using SerieList.Application.AppModels.Episode;
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
    }
}
