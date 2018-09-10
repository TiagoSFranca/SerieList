using SerieList.Application.AppModels.Episode;
using AutoMapper;
using SerieList.Presentation.Models.Post;
using SerieList.Extras.Util;
using SerieList.Application.CommonAppModels;

namespace SerieList.Presentation.AutoMapper.Profiles
{
    public class EpisodeProfilePresentation : Profile
    {
        public EpisodeProfilePresentation()
        {
            CreateMap<EpisodePostModel, EpisodeAppModel>();

            CreateMap<PagingResultAppModel<EpisodeStatusAppModel>, PagingResultSearchModel<EpisodeAppModel>>().ReverseMap();
        }
    }
}