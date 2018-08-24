using SerieList.Application.AppModels.User;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Extensions.User
{
    internal static class UserExtension
    {
        public static UserModel MapperToDomain(this UserAppModel obj)
        {
            return AutoMapper.Mapper.Map<UserModel>(obj);
        }

        public static UserAppModel MapperToAppModel(this UserModel obj)
        {
            return AutoMapper.Mapper.Map<UserAppModel>(obj);
        }
    }
}
