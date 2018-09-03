using SerieList.Application.AppModels.User;
using AutoMapper;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.AutoMapper.Profiles
{
    public class UserProfilePresentation : Profile
    {
        public UserProfilePresentation()
        {
            CreateMap<UserPostModel, UserAppModel>();

            CreateMap<UserRegisterModel, UserAppModel>()
                .ForMember(dest => dest.UserInfo,
                src => src.MapFrom(
                    p => new UserInfoAppModel()
                    {
                        Email = p.Email,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        UserName = p.UserName,
                        PasswordHash = p.PasswordHash
                    }));

            CreateMap<UserProductPostModel, UserProductAppModel>();
        }
    }
}