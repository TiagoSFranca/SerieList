﻿using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.Season
{
    public class SeasonStatusSearch
    {
        public List<int> IdList { get; set; }
        public string Description { get; set; }
        public bool? Excluded { get; set; }
    }
}