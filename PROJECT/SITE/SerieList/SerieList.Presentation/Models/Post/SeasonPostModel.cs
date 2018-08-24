using System;

namespace SerieList.Presentation.Models.Post
{
    public class SeasonPostModel
    {
        public int IdSeason { get; set; }
        public int IdVisibility { get; set; }
        public int IdSeasonStatus { get; set; }
        public int IdProduct { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}