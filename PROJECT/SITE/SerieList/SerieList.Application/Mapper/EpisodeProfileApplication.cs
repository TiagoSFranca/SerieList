using SerieList.Application.AppModels.Episode;
using AutoMapper;
using SerieList.Domain.Entitites.Episode;

namespace SerieList.Application.Mapper
{
    public class EpisodeProfileApplication : Profile
    {
        public EpisodeProfileApplication()
        {
            CreateMap<EpisodeStatusModel, EpisodeStatusAppModel>().ReverseMap();

            CreateMap<EpisodeModel, EpisodeAppModel>();
            CreateMap<EpisodeAppModel, EpisodeModel>()
                .ForMember(dest => dest.Product, src => src.Ignore())
                .ForMember(dest => dest.Visibility, src => src.Ignore())
                .ForMember(dest => dest.EpisodeStatus, src => src.Ignore())
                .ForMember(dest => dest.Season, src => src.Ignore());

        }
    }
}
