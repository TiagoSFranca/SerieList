using System.Collections.Generic;

namespace SerieList.Domain.Entitites.User
{
    public class UserSeasonStatusModel
    {
        public int IdUserSeasonStatus { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<UserSeasonModel> UserSeasons { get; set; }
    }
}
