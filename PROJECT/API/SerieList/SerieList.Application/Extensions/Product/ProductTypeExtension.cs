using SerieList.Application.AppModels.Product;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Product;

namespace SerieList.Application.Extensions.Product
{
    internal static class ProductTypeExtension
    {
        public static ProductTypeModel MapperToDomain(this ProductTypeAppModel obj)
        {
            return AutoMapper.Mapper.Map<ProductTypeModel>(obj);
        }

        public static ProductTypeAppModel MapperToAppModel(this ProductTypeModel obj)
        {
            return AutoMapper.Mapper.Map<ProductTypeAppModel>(obj);
        }

        public static PagingResultAppModel<ProductTypeAppModel> MapperToAppModel(this PagingResultModel<ProductTypeModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<ProductTypeAppModel>>(obj);
        }
    }
}
