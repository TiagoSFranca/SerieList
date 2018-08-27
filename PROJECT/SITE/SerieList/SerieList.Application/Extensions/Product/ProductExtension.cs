using SerieList.Application.AppModels.Product;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Product;

namespace SerieList.Application.Extensions.Product
{
    internal static class ProductExtension
    {
        public static ProductModel MapperToDomain(this ProductAppModel obj)
        {
            return AutoMapper.Mapper.Map<ProductModel>(obj);
        }

        public static ProductAppModel MapperToAppModel(this ProductModel obj)
        {
            return AutoMapper.Mapper.Map<ProductAppModel>(obj);
        }

        public static PagingResultAppModel<ProductAppModel> MapperToAppModel(this PagingResultModel<ProductModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<ProductAppModel>>(obj);
        }
    }
}
