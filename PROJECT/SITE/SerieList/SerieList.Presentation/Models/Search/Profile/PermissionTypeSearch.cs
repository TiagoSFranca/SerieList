﻿using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.Profile
{
    public class PermissionTypeSearch : PagingSearch
    {
        public List<int> IdList { get; set; }
        public string Description { get; set; }
        public bool? Excluded { get; set; }
    }
}