using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Extensions.User
{
    internal static class UserProductExtension
    {
        public static UserProductModel MapperToDomain(this UserProductAppModel obj)
        {
            return AutoMapper.Mapper.Map<UserProductModel>(obj);
        }

        public static UserProductAppModel MapperToAppModel(this UserProductModel obj)
        {
            return AutoMapper.Mapper.Map<UserProductAppModel>(obj);
        }

        public static PagingResultAppModel<UserProductAppModel> MapperToAppModel(this PagingResultModel<UserProductModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<UserProductAppModel>>(obj);
        }
    }
}
