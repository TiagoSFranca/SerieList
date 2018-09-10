using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Entitites.Season;
using SerieList.Domain.Entitites.Token;
using System;
using System.Collections.Generic;

namespace SerieList.Domain.Entitites.User
{
    public partial class UserModel
    {
        public int IdUser { get; set; }
        public int IdProfile { get; set; }
        public int IdUserStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual UserInfoModel UserInfo { get; set; }
        public virtual ProfileModel Profile { get; set; }
        public virtual UserStatusModel UserStatus { get; set; }

        public virtual ICollection<TokenProviderModel> TokenProviders { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
        public virtual ICollection<SeasonModel> Seasons { get; set; }
        public virtual ICollection<EpisodeModel> Episodes { get; set; }
        public virtual ICollection<PasswordHistoryModel> PasswordResets { get; set; }
        public virtual ICollection<UserProductModel> UserProducts { get; set; }
        public virtual ICollection<UserEpisodeModel> UserEpisodes { get; set; }
        public virtual ICollection<UserSeasonModel> UserSeasons { get; set; }
    }
}
