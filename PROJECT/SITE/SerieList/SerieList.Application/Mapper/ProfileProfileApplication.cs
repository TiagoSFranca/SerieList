using SerieList.Application.AppModels.Profile;
using AutoMapper;
using SerieList.Domain.Entitites.Profile;

namespace SerieList.Application.Mapper
{
    public class ProfileProfileApplication : Profile
    {
        public ProfileProfileApplication()
        {
            CreateMap<PermissionGroupModel, PermissionGroupAppModel>().ReverseMap();
            CreateMap<PermissionTypeModel, PermissionTypeAppModel>().ReverseMap();
            CreateMap<PermissionModel, PermissionAppModel>().ReverseMap();

            CreateMap<ProfileModel, ProfileAppModel>().ReverseMap();

            CreateMap<ProfilePermissionModel, ProfilePermissionAppModel>();
            CreateMap<ProfilePermissionAppModel, ProfilePermissionModel>()
                .ForMember(dest => dest.Permission, src => src.Ignore());
        }
    }
}
