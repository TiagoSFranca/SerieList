using SerieList.Application.AppModels.Episode;
using AutoMapper;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.AutoMapper.Profiles
{
    public class EpisodeProfilePresentation : Profile
    {
        public EpisodeProfilePresentation()
        {
            CreateMap<EpisodePostModel, EpisodeAppModel>();
        }
    }
}