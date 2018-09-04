using SerieList.Application.AppModels.Season;
using System;

namespace SerieList.Application.AppModels.User
{
    public class UserSeasonAppModel
    {
        public int IdUser { get; set; }
        public int IdSeason { get; set; }
        public int IdUserSeasonStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual UserSimplifiedAppModel User { get; set; }
        public virtual SeasonAppModel Season { get; set; }
        public virtual UserSeasonStatusAppModel UserSeasonStatus { get; set; }
    }
}
