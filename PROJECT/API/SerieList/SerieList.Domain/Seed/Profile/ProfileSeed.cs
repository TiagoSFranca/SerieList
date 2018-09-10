using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Profile
{
    public class ProfileSeed
    {
        public static ProfileModel Admin { get { return new ProfileModel() { IdProfile = 1, Description = "Administrador", Excluded = false }; } }

        public static ProfileModel CommomUser { get { return new ProfileModel() { IdProfile = 2, Description = "Usuário Comum", Excluded = false }; } }

        public static List<ProfileModel> Seeds
        {
            get
            {
                return new List<ProfileModel>()
                {
                    Admin,
                    CommomUser
                };
            }
        }

    }
}
