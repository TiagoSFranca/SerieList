using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.User
{
    public class UserSeasonSearch : PagingSearch
    {
        public List<int> IdUserList { get; set; }
        public List<int> IdSeasonList { get; set; }
        public List<int> IdUserSeasonStatusList { get; set; }
        public string Title { get; set; }
        public bool? Excluded { get; set; }
        public bool? AssociatedExcluded { get; set; }
    }
}