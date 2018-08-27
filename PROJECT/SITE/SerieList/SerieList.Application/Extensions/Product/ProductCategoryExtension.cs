using SerieList.Application.AppModels.Product;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Product;

namespace SerieList.Application.Extensions.Product
{
    internal static class ProductCategoryExtension
    {
        public static ProductCategoryModel MapperToDomain(this ProductCategoryAppModel obj)
        {
            return AutoMapper.Mapper.Map<ProductCategoryModel>(obj);
        }

        public static ProductCategoryAppModel MapperToAppModel(this ProductCategoryModel obj)
        {
            return AutoMapper.Mapper.Map<ProductCategoryAppModel>(obj);
        }

        public static PagingResultAppModel<ProductCategoryAppModel> MapperToAppModel(this PagingResultModel<ProductCategoryModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<ProductCategoryAppModel>>(obj);
        }
    }
}
