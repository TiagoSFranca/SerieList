using SerieList.Application.AppModels.Product;
using SerieList.Application.AppModels.User;
using System;

namespace SerieList.Application.AppModels.Season
{
    public class SeasonAppModel
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

        public virtual VisibilityAppModel Visibility { get; set; }
        public virtual ProductAppModel Product { get; set; }
        public virtual SeasonStatusAppModel SeasonStatus { get; set; }
        public UserSimplifiedAppModel User { get; set; }
    }
}
