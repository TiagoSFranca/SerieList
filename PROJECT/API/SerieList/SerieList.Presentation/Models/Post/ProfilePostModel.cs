using System;
using System.Collections.Generic;

namespace SerieList.Presentation.Models.Post
{
    public class ProfilePostModel
    {
        public int IdProfile { get; set; }
        public string Description { get; set; }

        public List<int> Permissions { get; set; }
    }
}