using SerieList.Application.AppModels.Product;
using AutoMapper;
using SerieList.Domain.Entitites.Product;

namespace SerieList.Application.Mapper
{
    public class ProductProfileApplication : Profile
    {
        public ProductProfileApplication()
        {
            CreateMap<ProductTypeModel, ProductTypeAppModel>().ReverseMap();

            CreateMap<ProductCategoryModel, ProductCategoryAppModel>().ReverseMap();

            CreateMap<ProductStatusModel, ProductStatusAppModel>().ReverseMap();

            CreateMap<ProductModel, ProductAppModel>();
            CreateMap<ProductAppModel, ProductModel>()
                .ForMember(dest => dest.Visibility, src => src.Ignore())
                .ForMember(dest => dest.Seasons, src => src.Ignore())
                .ForMember(dest => dest.ProductStatus, src => src.Ignore())
                .ForMember(dest => dest.ProductType, src => src.Ignore())
                .ForMember(dest => dest.Episodes, src => src.Ignore());

            CreateMap<ProductInfoModel, ProductInfoAppModel>();
            CreateMap<ProductInfoAppModel, ProductInfoModel>()
                .ForMember(dest => dest.Product, src => src.Ignore());

            CreateMap<ProductProductCategoryModel, ProductProductCategoryAppModel>();
            CreateMap<ProductProductCategoryAppModel, ProductProductCategoryModel>()
                .ForMember(dest => dest.Category, src => src.Ignore());

            CreateMap<VisibilityModel, VisibilityAppModel>().ReverseMap();
        }
    }

}
