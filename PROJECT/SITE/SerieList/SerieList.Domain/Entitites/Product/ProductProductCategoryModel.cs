using System;

namespace SerieList.Domain.Entitites.Product
{
    public partial class ProductProductCategoryModel
    {
        public int IdProduct { get; set; }
        public int IdCategory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual ProductModel Product { get; set; }
        public virtual ProductCategoryModel Category { get; set; }

    }
}
