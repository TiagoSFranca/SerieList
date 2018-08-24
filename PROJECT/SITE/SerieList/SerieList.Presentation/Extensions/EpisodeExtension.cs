using SerieList.Application.AppModels.Episode;
using AutoMapper;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.Extensions
{
    internal static class EpisodeExtension
    {
        public static EpisodeAppModel MapperToAppModel(this EpisodePostModel obj)
        {
            return Mapper.Map<EpisodeAppModel>(obj);
        }
    }
}