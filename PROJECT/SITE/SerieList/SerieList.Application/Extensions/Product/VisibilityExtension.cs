using SerieList.Application.AppModels.Product;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Product;

namespace SerieList.Application.Extensions.Product
{
    internal static class VisibilityExtension
    {
        public static VisibilityModel MapperToDomain(this VisibilityAppModel obj)
        {
            return AutoMapper.Mapper.Map<VisibilityModel>(obj);
        }

        public static VisibilityAppModel MapperToAppModel(this VisibilityModel obj)
        {
            return AutoMapper.Mapper.Map<VisibilityAppModel>(obj);
        }

        public static PagingResultAppModel<VisibilityAppModel> MapperToAppModel(this PagingResultModel<VisibilityModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<VisibilityAppModel>>(obj);
        }
    }
}
