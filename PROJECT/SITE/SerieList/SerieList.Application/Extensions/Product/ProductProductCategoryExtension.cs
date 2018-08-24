using SerieList.Application.AppModels.Product;
using SerieList.Domain.Entitites.Product;

namespace SerieList.Application.Extensions.Product
{
    internal static class ProductProductCategoryExtension
    {
        public static ProductProductCategoryModel MapperToDomain(this ProductProductCategoryAppModel obj)
        {
            return AutoMapper.Mapper.Map<ProductProductCategoryModel>(obj);
        }

        public static ProductProductCategoryAppModel MapperToAppModel(this ProductProductCategoryModel obj)
        {
            return AutoMapper.Mapper.Map<ProductProductCategoryAppModel>(obj);
        }
    }
}
