using SerieList.Application.AppModels.User;
using AutoMapper;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.Extensions
{
    internal static class UserExtension
    {
        public static UserAppModel MapperToAppModel(this UserPostModel obj)
        {
            return Mapper.Map<UserAppModel>(obj);
        }

        public static UserAppModel MapperToAppModel(this UserRegisterModel obj)
        {
            return Mapper.Map<UserAppModel>(obj);
        }

    }
}