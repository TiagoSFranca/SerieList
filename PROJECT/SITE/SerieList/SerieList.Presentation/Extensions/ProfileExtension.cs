using SerieList.Application.AppModels.Profile;
using AutoMapper;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.Extensions
{
    internal static class ProfileExtension
    {
        public static ProfileAppModel MapperToAppModel(this ProfilePostModel obj)
        {
            return Mapper.Map<ProfileAppModel>(obj);
        }
    }
}