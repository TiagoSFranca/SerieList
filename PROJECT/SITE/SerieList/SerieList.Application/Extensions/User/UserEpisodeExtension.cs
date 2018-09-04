using SerieList.Application.AppModels.User;
using SerieList.Application.CommonAppModels;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Entitites.User;

namespace SerieList.Application.Extensions.User
{
    internal static class UserEpisodeExtension
    {
        public static UserEpisodeModel MapperToDomain(this UserEpisodeAppModel obj)
        {
            return AutoMapper.Mapper.Map<UserEpisodeModel>(obj);
        }

        public static UserEpisodeAppModel MapperToAppModel(this UserEpisodeModel obj)
        {
            return AutoMapper.Mapper.Map<UserEpisodeAppModel>(obj);
        }

        public static PagingResultAppModel<UserEpisodeAppModel> MapperToAppModel(this PagingResultModel<UserEpisodeModel> obj)
        {
            return AutoMapper.Mapper.Map<PagingResultAppModel<UserEpisodeAppModel>>(obj);
        }
    }
}
