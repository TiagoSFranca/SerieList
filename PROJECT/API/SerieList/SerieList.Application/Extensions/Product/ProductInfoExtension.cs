using SerieList.Application.AppModels.Product;
using SerieList.Domain.Entitites.Product;

namespace SerieList.Application.Extensions.Product
{
    internal static class ProductInfoExtension
    {
        public static ProductInfoModel MapperToDomain(this ProductInfoAppModel obj)
        {
            return AutoMapper.Mapper.Map<ProductInfoModel>(obj);
        }

        public static ProductInfoAppModel MapperToAppModel(this ProductInfoModel obj)
        {
            return AutoMapper.Mapper.Map<ProductInfoAppModel>(obj);
        }
    }
}
