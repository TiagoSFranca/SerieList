using SerieList.Application.AppModels.Profile;
using AutoMapper;
using SerieList.Presentation.Models.Post;
using SerieList.Application.CommonAppModels;
using SerieList.Extras.Util;

namespace SerieList.Presentation.Extensions
{
    internal static class ProfileExtension
    {
        public static ProfileAppModel MapperToAppModel(this ProfilePostModel obj)
        {
            return Mapper.Map<ProfileAppModel>(obj);
        }

        public static PagingResultSearchModel<PermissionGroupAppModel> MapperToView(this PagingResultAppModel<PermissionGroupAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<PermissionGroupAppModel>>(obj);
        }

        public static PagingResultSearchModel<PermissionAppModel> MapperToView(this PagingResultAppModel<PermissionAppModel> obj)
        {
            return Mapper.Map<PagingResultSearchModel<PermissionAppModel>>(obj);
        }
    }
}