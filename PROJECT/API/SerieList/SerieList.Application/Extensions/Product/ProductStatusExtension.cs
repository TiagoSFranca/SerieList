using SerieList.Application.AppModels.Product;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Product;

namespace SerieList.Application.Extensions.Product
{
    internal static class ProductStatusExtension
    {
        public static ProductStatusModel MapperToDomain(this ProductStatusAppModel obj)
        {
            return AutoMapper.Mapper.Map<ProductStatusModel>(obj);
        }

        public static ProductStatusAppModel MapperToAppModel(this ProductStatusModel obj)
        {
            return AutoMapper.Mapper.Map<ProductStatusAppModel>(obj);
        }

        public static PagingResultAppModel<ProductStatusAppModel> MapperToAppModel(this PagingResultModel<ProductStatusModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<ProductStatusAppModel>>(obj);
        }
    }
}
