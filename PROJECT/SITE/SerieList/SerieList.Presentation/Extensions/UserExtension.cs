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
    }
}