using SerieList.Application.AppModels.Product;
using AutoMapper;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.Extensions
{
    internal static class ProductExtension
    {
        public static ProductAppModel MapperToAppModel(this ProductPostModel obj)
        {
            return Mapper.Map<ProductAppModel>(obj);
        }
    }
}