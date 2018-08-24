using System;
using System.Collections.Generic;

namespace SerieList.Presentation.Models.Post
{
    public class ProductPostModel
    {
        public int IdProduct { get; set; }
        public int IdProductStatus { get; set; }
        public int IdProductType { get; set; }
        public int IdVisibility { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? BeginAt { get; set; }
        public DateTime? EndAt { get; set; }

        public List<int> Categories { get; set; }
    }
}