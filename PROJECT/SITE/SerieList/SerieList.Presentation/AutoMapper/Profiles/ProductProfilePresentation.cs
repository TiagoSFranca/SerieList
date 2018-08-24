using SerieList.Application.AppModels.Product;
using AutoMapper;
using System.Linq;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.AutoMapper.Profiles
{
    public class ProductProfilePresentation : Profile
    {
        public ProductProfilePresentation()
        {
            CreateMap<ProductPostModel, ProductAppModel>()
                .ForMember(dest => dest.Categories,
                src => src.MapFrom(
                    p => p.Categories.Select(
                        c => new ProductProductCategoryAppModel()
                        {
                            IdCategory = c,
                            IdProduct = p.IdProduct
                        })))
                .ForMember(dest => dest.ProductInfo,
                src => src.MapFrom(
                    p => new ProductInfoAppModel()
                    {
                        IdProduct = p.IdProduct,
                        BeginAt = p.BeginAt,
                        EndAt = p.EndAt,
                        Description = p.Description,
                        Title = p.Title
                    }));

            CreateMap<ProductCategoryPostModel, ProductCategoryAppModel>();
        }
    }
}