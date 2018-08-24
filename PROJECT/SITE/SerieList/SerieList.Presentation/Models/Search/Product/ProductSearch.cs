using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.Product
{
    public class ProductSearch
    {
        public List<int> IdList { get; set; }
        public List<int> IdProductTypeList { get; set; }
        public List<int> IdProductStatusList { get; set; }
        public List<int> IdVisibilityList { get; set; }
        public List<int> IdUserList { get; set; }
        public string Title { get; set; }
        public bool? Excluded { get; set; }
        public bool? AssociatedExcluded { get; set; }
    }
}