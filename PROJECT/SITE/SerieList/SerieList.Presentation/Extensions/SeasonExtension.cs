using SerieList.Application.AppModels.Season;
using AutoMapper;
using SerieList.Presentation.Models.Post;
using SerieList.Extras.Util;
using SerieList.Application.CommonAppModels;

namespace SerieList.Presentation.Extensions
{
    internal static class SeasonExtension
    {
        public static SeasonAppModel MapperToAppModel(this SeasonPostModel obj)
        {
            return Mapper.Map<SeasonAppModel>(obj);
        }

        public static PagingResultSearchModel<SeasonAppModel> MapperToView(this PagingResultAppModel<SeasonAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<SeasonAppModel>>(obj);
        }
    }
}