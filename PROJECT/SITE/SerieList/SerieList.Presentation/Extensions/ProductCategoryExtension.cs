using SerieList.Application.AppModels.Product;
using AutoMapper;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.Extensions
{
    internal static class ProductCategoryExtension
    {
        public static ProductCategoryAppModel MapperToAppModel(this ProductCategoryPostModel obj)
        {
            return Mapper.Map<ProductCategoryAppModel>(obj);
        }
    }
}