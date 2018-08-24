using SerieList.Application.AppModels.Season;
using AutoMapper;
using SerieList.Domain.Entitites.Season;

namespace SerieList.Application.Mapper
{
    public class SeasonProfileApplication : Profile
    {
        public SeasonProfileApplication()
        {
            CreateMap<SeasonStatusModel, SeasonStatusAppModel>().ReverseMap();

            CreateMap<SeasonModel, SeasonAppModel>();
            CreateMap<SeasonAppModel, SeasonModel>()
                .ForMember(dest => dest.Product, src => src.Ignore())
                .ForMember(dest => dest.Visibility, src => src.Ignore())
                .ForMember(dest => dest.SeasonStatus, src => src.Ignore())
                .ForMember(dest => dest.Episodes, src => src.Ignore());

        }
    }
}
