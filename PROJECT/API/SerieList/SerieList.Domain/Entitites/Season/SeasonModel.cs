using SerieList.Domain.Entitites.Episode;
using SerieList.Domain.Entitites.Product;
using SerieList.Domain.Entitites.User;
using System;
using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Season
{
    public partial class SeasonModel
    {
        public int IdSeason { get; set; }
        public int IdVisibility { get; set; }
        public int IdSeasonStatus { get; set; }
        public int IdProduct { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual VisibilityModel Visibility { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual SeasonStatusModel SeasonStatus { get; set; }
        public virtual UserModel User { get; set; }

        public virtual ICollection<EpisodeModel> Episodes { get; set; }
        public virtual ICollection<UserSeasonModel> UserSeasons { get; set; }

    }
}
