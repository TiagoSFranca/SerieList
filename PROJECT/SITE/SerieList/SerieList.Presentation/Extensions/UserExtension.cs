using SerieList.Application.AppModels.User;
using AutoMapper;
using SerieList.Presentation.Models.Post;
using SerieList.Application.CommonAppModels;
using SerieList.Extras.Util;

namespace SerieList.Presentation.Extensions
{
    internal static class UserExtension
    {
        public static UserAppModel MapperToAppModel(this UserPostModel obj)
        {
            return Mapper.Map<UserAppModel>(obj);
        }

        public static UserAppModel MapperToAppModel(this UserRegisterModel obj)
        {
            return Mapper.Map<UserAppModel>(obj);
        }

        public static UserProductAppModel MapperToAppModel(this UserProductPostModel obj)
        {
            return Mapper.Map<UserProductAppModel>(obj);
        }

        public static UserEpisodeAppModel MapperToAppModel(this UserEpisodePostModel obj)
        {
            return Mapper.Map<UserEpisodeAppModel>(obj);
        }

        public static UserSeasonAppModel MapperToAppModel(this UserSeasonPostModel obj)
        {
            return Mapper.Map<UserSeasonAppModel>(obj);
        }

        public static PagingResultSearchModel<UserAppModel> MapperToView(this PagingResultAppModel<UserAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<UserAppModel>>(obj);
        }

        public static PagingResultSearchModel<UserStatusAppModel> MapperToView(this PagingResultAppModel<UserStatusAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<UserStatusAppModel>>(obj);
        }

        public static PagingResultSearchModel<UserProductStatusAppModel> MapperToView(this PagingResultAppModel<UserProductStatusAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<UserProductStatusAppModel>>(obj);
        }

        public static PagingResultSearchModel<UserProductAppModel> MapperToView(this PagingResultAppModel<UserProductAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<UserProductAppModel>>(obj);
        }

        public static PagingResultSearchModel<UserEpisodeStatusAppModel> MapperToView(this PagingResultAppModel<UserEpisodeStatusAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<UserEpisodeStatusAppModel>>(obj);
        }

        public static PagingResultSearchModel<UserEpisodeAppModel> MapperToView(this PagingResultAppModel<UserEpisodeAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<UserEpisodeAppModel>>(obj);
        }

        public static PagingResultSearchModel<UserSeasonStatusAppModel> MapperToView(this PagingResultAppModel<UserSeasonStatusAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<UserSeasonStatusAppModel>>(obj);
        }

        public static PagingResultSearchModel<UserSeasonAppModel> MapperToView(this PagingResultAppModel<UserSeasonAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<UserSeasonAppModel>>(obj);
        }
    }
}