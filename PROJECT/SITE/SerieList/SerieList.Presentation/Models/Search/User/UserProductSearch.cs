using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.User
{
    public class UserProductSearch : PagingSearch
    {
        public List<int> IdUserList { get; set; }
        public List<int> IdProductList { get; set; }
        public List<int> IdUserProductStatusList { get; set; }
        public string Title { get; set; }
        public bool? Excluded { get; set; }
        public bool? AssociatedExcluded { get; set; }
    }
}