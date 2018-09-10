using SerieList.Application.AppModels.Episode;
using AutoMapper;
using SerieList.Presentation.Models.Post;
using SerieList.Extras.Util;
using SerieList.Application.CommonAppModels;

namespace SerieList.Presentation.Extensions
{
    internal static class EpisodeExtension
    {
        public static EpisodeAppModel MapperToAppModel(this EpisodePostModel obj)
        {
            return Mapper.Map<EpisodeAppModel>(obj);
        }

        public static PagingResultSearchModel<EpisodeStatusAppModel> MapperToView(this PagingResultAppModel<EpisodeStatusAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<EpisodeStatusAppModel>>(obj);
        }

        public static PagingResultSearchModel<EpisodeAppModel> MapperToView(this PagingResultAppModel<EpisodeAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<EpisodeAppModel>>(obj);
        }
    }
}