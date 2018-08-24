using System;

namespace SerieList.Application.AppModels.Product
{
    public class ProductProductCategoryAppModel
    {
        public int IdProduct { get; set; }
        public int IdCategory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public ProductCategoryAppModel Category { get; set; }
    }
}
