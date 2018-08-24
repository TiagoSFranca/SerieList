using SerieList.Application.AppModels.Season;
using AutoMapper;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.Extensions
{
    internal static class SeasonExtension
    {
        public static SeasonAppModel MapperToAppModel(this SeasonPostModel obj)
        {
            return Mapper.Map<SeasonAppModel>(obj);
        }
        
    }
}