using SerieList.Domain.Entitites.Episode;
using System;

namespace SerieList.Domain.Entitites.User
{
    public partial class UserEpisodeModel
    {
        public int IdUser { get; set; }
        public int IdEpisode { get; set; }
        public int IdUserEpisodeStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual UserModel User { get; set; }
        public virtual EpisodeModel Episode { get; set; }
        public virtual UserEpisodeStatusModel UserEpisodeStatus { get; set; }

    }
}
