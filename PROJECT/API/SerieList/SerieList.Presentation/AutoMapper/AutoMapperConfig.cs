using SerieList.Application.Mapper;
using AutoMapper;
using SerieList.Presentation.AutoMapper.Profiles;

namespace SerieList.Presentation.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile(new ConfigProfileApplication());

                x.AddProfile(new PagingProfileApplication());

                x.AddProfile(new ProductProfileApplication());
                x.AddProfile(new ProductProfilePresentation());

                x.AddProfile(new EpisodeProfileApplication());
                x.AddProfile(new EpisodeProfilePresentation());

                x.AddProfile(new SeasonProfileApplication());
                x.AddProfile(new SeasonProfilePresentation());

                x.AddProfile(new ProfileProfileApplication());
                x.AddProfile(new ProfileProfilePresentation());

                x.AddProfile(new UserProfileApplication());
                x.AddProfile(new UserProfilePresentation());

            });
        }
    }
}