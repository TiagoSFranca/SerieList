using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Extensions.User
{
    internal static class UserProductStatusExtension
    {
        public static UserProductStatusModel MapperToDomain(this UserProductStatusAppModel obj)
        {
            return AutoMapper.Mapper.Map<UserProductStatusModel>(obj);
        }

        public static UserProductStatusAppModel MapperToAppModel(this UserProductStatusModel obj)
        {
            return AutoMapper.Mapper.Map<UserProductStatusAppModel>(obj);
        }

        public static PagingResultAppModel<UserProductStatusAppModel> MapperToAppModel(this PagingResultModel<UserProductStatusModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<UserProductStatusAppModel>>(obj);
        }
    }
}
