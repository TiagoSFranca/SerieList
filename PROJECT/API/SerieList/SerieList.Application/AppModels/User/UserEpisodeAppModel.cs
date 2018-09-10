using SerieList.Application.AppModels.Episode;
using System;

namespace SerieList.Application.AppModels.User
{
    public class UserEpisodeAppModel
    {
        public int IdUser { get; set; }
        public int IdEpisode { get; set; }
        public int IdUserEpisodeStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual UserSimplifiedAppModel User { get; set; }
        public virtual EpisodeAppModel Episode { get; set; }
        public virtual UserEpisodeStatusAppModel UserEpisodeStatus { get; set; }
    }
}
