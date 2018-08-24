using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.Season
{
    public class SeasonSearch
    {
        public int[] IdList { get; set; }
        public List<int> IdProductList { get; set; }
        public List<int> IdSeasonStatusList { get; set; }
        public List<int> IdVisibilityList { get; set; }
        public List<int> IdUserList { get; set; }
        public string Title { get; set; }
        public bool? Excluded { get; set; }
        public bool? AssociatedExcluded { get; set; }
    }
}