using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Extensions.User
{
    internal static class UserEpisodeStatusExtension
    {
        public static UserEpisodeStatusModel MapperToDomain(this UserEpisodeStatusAppModel obj)
        {
            return AutoMapper.Mapper.Map<UserEpisodeStatusModel>(obj);
        }

        public static UserEpisodeStatusAppModel MapperToAppModel(this UserEpisodeStatusModel obj)
        {
            return AutoMapper.Mapper.Map<UserEpisodeStatusAppModel>(obj);
        }

        public static PagingResultAppModel<UserEpisodeStatusAppModel> MapperToAppModel(this PagingResultModel<UserEpisodeStatusModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<UserEpisodeStatusAppModel>>(obj);
        }
    }
}
