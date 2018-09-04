using SerieList.Domain.Entitites.Season;
using System;

namespace SerieList.Domain.Entitites.User
{
    public partial class UserSeasonModel
    {
        public int IdUser { get; set; }
        public int IdSeason { get; set; }
        public int IdUserSeasonStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual UserModel User { get; set; }
        public virtual SeasonModel Season { get; set; }
        public virtual UserSeasonStatusModel UserSeasonStatus { get; set; }

    }
}
