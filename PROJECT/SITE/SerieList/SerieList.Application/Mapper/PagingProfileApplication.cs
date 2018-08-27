using AutoMapper;
using SerieList.Application.AppModels.Episode;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.Episode;

namespace SerieList.Application.Mapper
{
    public class PagingProfileApplication : Profile
    {
        public PagingProfileApplication()
        {
            CreateMap<PagingResultModel<EpisodeStatusModel>, PagingResultAppModel<EpisodeStatusAppModel>>();
            CreateMap<PagingResultModel<EpisodeModel>, PagingResultAppModel<EpisodeAppModel>>();
        }
    }
}
