using SerieList.Application.AppModels.Product;
using SerieList.Application.AppModels.Season;
using System;

namespace SerieList.Application.AppModels.Episode
{
    public class EpisodeAppModel
    {
        public int IdEpisode { get; set; }
        public int IdVisibility { get; set; }
        public int IdEpisodeStatus { get; set; }
        public int IdProduct { get; set; }
        public int? IdSeason { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual VisibilityAppModel Visibility { get; set; }
        public virtual ProductAppModel Product { get; set; }
        public virtual EpisodeStatusAppModel EpisodeStatus { get; set; }
        public virtual SeasonAppModel Season { get; set; }
    }
}
