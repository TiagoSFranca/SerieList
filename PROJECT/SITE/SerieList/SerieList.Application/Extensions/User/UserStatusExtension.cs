using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
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

        public static PagingResultAppModel<UserStatusAppModel> MapperToAppModel(this PagingResultModel<UserStatusModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<UserStatusAppModel>>(obj);
        }
    }
}
