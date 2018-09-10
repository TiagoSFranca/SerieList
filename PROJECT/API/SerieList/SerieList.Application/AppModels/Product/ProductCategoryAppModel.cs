using System;

namespace SerieList.Application.AppModels.Product
{
    public class ProductCategoryAppModel
    {
        public int IdProductCategory { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Excluded { get; set; }
    }
}
