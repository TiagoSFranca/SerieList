using AutoMapper;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;

namespace SerieList.Application.Mapper
{
    public class ConfigProfileApplication : Profile
    {
        public ConfigProfileApplication()
        {
            CreateMap<string, string>().ConvertUsing(str => (str ?? "").Trim());
            CreateMap<PagingModel, PagingAppModel>();
        }
    }
}
