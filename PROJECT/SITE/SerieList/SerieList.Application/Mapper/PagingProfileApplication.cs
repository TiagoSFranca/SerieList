using AutoMapper;
using SerieList.Application.AppModels.Episode;
using SerieList.Application.AppModels.Product;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Entitites.Product;

namespace SerieList.Application.Mapper
{
    public class PagingProfileApplication : Profile
    {
        public PagingProfileApplication()
        {
            CreateMap<PagingResultModel<EpisodeStatusModel>, PagingResultAppModel<EpisodeStatusAppModel>>();
            CreateMap<PagingResultModel<EpisodeModel>, PagingResultAppModel<EpisodeAppModel>>();
            CreateMap<PagingResultModel<ProductCategoryModel>, PagingResultAppModel<ProductCategoryAppModel>>();
            CreateMap<PagingResultModel<ProductModel>, PagingResultAppModel<ProductAppModel>>();
        }
    }
}
