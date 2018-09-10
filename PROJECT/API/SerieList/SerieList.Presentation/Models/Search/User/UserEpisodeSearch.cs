using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.User
{
    public class UserEpisodeSearch : PagingSearch
    {
        public List<int> IdUserList { get; set; }
        public List<int> IdEpisodeList { get; set; }
        public List<int> IdUserEpisodeStatusList { get; set; }
        public string Title { get; set; }
        public bool? Excluded { get; set; }
        public bool? AssociatedExcluded { get; set; }
    }
}