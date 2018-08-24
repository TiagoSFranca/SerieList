using SerieList.Application.AppModels.Profile;
using AutoMapper;
using System.Linq;
using SerieList.Presentation.Models.Post;

namespace SerieList.Presentation.AutoMapper.Profiles
{
    public class ProfileProfilePresentation : Profile
    {
        public ProfileProfilePresentation()
        {
            CreateMap<ProfilePostModel, ProfileAppModel>()
                .ForMember(dest => dest.Permissions, src => src.MapFrom(p => p.Permissions.Select(c => new ProfilePermissionAppModel() { IdPermission = c, IdProfile = p.IdProfile })));
        }
    }
}