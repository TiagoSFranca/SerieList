using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.Profile
{
    public class PermissionSearch : PagingSearch
    {
        public List<int> IdList { get; set; }
        public List<int> IdPermissionTypeList { get; set; }
        public List<int> IdPermissionGroupList { get; set; }
        public bool? Excluded { get; set; }
        public bool? AssociatedExcluded { get; set; }
    }
}