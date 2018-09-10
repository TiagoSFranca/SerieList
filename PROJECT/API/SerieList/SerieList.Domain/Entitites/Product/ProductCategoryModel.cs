using System;
using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Product
{
    public partial class ProductCategoryModel
    {
        public int IdProductCategory { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<ProductProductCategoryModel> Products { get; set; }
    }
}
