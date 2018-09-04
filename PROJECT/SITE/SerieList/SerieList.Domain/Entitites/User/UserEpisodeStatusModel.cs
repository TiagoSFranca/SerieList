using System.Collections.Generic;

namespace SerieList.Domain.Entitites.User
{
    public class UserEpisodeStatusModel
    {
        public int IdUserEpisodeStatus { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        //public virtual ICollection<UserEpisodeModel> UserEpisodes { get; set; }
    }
}
