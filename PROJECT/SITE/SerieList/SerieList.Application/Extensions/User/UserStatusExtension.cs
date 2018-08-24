using SerieList.Application.AppModels.User;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Extensions.User
{
    internal static class UserStatusExtension
    {
        public static UserStatusModel MapperToDomain(this UserStatusAppModel obj)
        {
            return AutoMapper.Mapper.Map<UserStatusModel>(obj);
        }

        public static UserStatusAppModel MapperToAppModel(this UserStatusModel obj)
        {
            return AutoMapper.Mapper.Map<UserStatusAppModel>(obj);
        }
    }
}
