using SerieList.Application.AppModels.User;
using AutoMapper;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Mapper
{
    public class UserProfileApplication : Profile
    {
        public UserProfileApplication()
        {
            CreateMap<UserStatusModel, UserStatusAppModel>().ReverseMap();

            CreateMap<UserModel, UserAppModel>();
            CreateMap<UserAppModel, UserModel>()
                .ForMember(dest => dest.Profile, src => src.Ignore())
                .ForMember(dest => dest.UserStatus, src => src.Ignore());

            CreateMap<UserInfoModel, UserInfoAppModel>()
                .ForMember(dest => dest.PasswordHash, src => src.Ignore());

            CreateMap<UserInfoAppModel, UserInfoModel>()
                .ForMember(dest => dest.User, src => src.Ignore());


            CreateMap<UserModel, UserSimplifiedAppModel>().ReverseMap();
            CreateMap<UserInfoModel, UserInfoSimplifiedAppModel>().ReverseMap();

            CreateMap<UserProductStatusModel, UserProductStatusAppModel>().ReverseMap();

            CreateMap<UserProductModel, UserProductAppModel>();
            CreateMap<UserProductAppModel, UserProductModel>()
                .ForMember(dest => dest.User, src => src.Ignore())
                .ForMember(dest => dest.Product, src => src.Ignore())
                .ForMember(dest => dest.UserProductStatus, src => src.Ignore());

            CreateMap<UserEpisodeStatusModel, UserEpisodeStatusAppModel>().ReverseMap();

            CreateMap<UserEpisodeModel, UserEpisodeAppModel>();
            CreateMap<UserEpisodeAppModel, UserEpisodeModel>()
                .ForMember(dest => dest.User, src => src.Ignore())
                .ForMember(dest => dest.Episode, src => src.Ignore())
                .ForMember(dest => dest.UserEpisodeStatus, src => src.Ignore());

            CreateMap<UserSeasonStatusModel, UserSeasonStatusAppModel>().ReverseMap();

            CreateMap<UserSeasonModel, UserSeasonAppModel>();
            CreateMap<UserSeasonAppModel, UserSeasonModel>()
                .ForMember(dest => dest.User, src => src.Ignore())
                .ForMember(dest => dest.Season, src => src.Ignore())
                .ForMember(dest => dest.UserSeasonStatus, src => src.Ignore());

        }
    }
}
