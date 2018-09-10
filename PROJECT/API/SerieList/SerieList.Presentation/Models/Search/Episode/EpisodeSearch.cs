using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.Episode
{
    public class EpisodeSearch : PagingSearch
    {
        public List<int> IdList { get; set; }
        public List<int> IdProductList { get; set; }
        public List<int> IdEpisodeStatusList { get; set; }
        public List<int> IdVisibilityList { get; set; }
        public List<int> IdSeasonList { get; set; }
        public List<int> IdUserList { get; set; }
        public string Title { get; set; }
        public bool? Excluded { get; set; }
        public bool? AssociatedExcluded { get; set; }
    }
}