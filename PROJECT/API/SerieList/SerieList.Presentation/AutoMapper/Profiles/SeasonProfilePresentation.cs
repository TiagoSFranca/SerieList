using SerieList.Application.AppModels.Season;
using AutoMapper;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.AutoMapper.Profiles
{
    public class SeasonProfilePresentation : Profile
    {
        public SeasonProfilePresentation()
        {
            CreateMap<SeasonPostModel, SeasonAppModel>();
        }
    }
}