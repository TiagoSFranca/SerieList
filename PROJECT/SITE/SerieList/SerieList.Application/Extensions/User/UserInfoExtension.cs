using SerieList.Application.AppModels.User;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Extensions.User
{
    internal static class UserInfoExtension
    {
        public static UserInfoModel MapperToDomain(this UserInfoAppModel obj)
        {
            return AutoMapper.Mapper.Map<UserInfoModel>(obj);
        }

        public static UserInfoAppModel MapperToAppModel(this UserInfoModel obj)
        {
            return AutoMapper.Mapper.Map<UserInfoAppModel>(obj);
        }
    }
}
