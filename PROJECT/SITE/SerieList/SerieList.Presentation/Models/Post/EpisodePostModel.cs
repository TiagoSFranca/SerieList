using System;

namespace SerieList.Presentation.Models.Post
{
    public class EpisodePostModel
    {
        public int IdEpisode { get; set; }
        public int IdVisibility { get; set; }
        public int IdEpisodeStatus { get; set; }
        public int IdProduct { get; set; }
        public int? IdSeason { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}