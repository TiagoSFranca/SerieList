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

            CreateMap<UserProductStatusModel, UserProductStatusAppModel>().ReverseMap();

        }
    }
}
