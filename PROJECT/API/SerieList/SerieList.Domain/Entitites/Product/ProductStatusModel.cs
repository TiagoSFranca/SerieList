using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Product
{
    public partial class ProductStatusModel
    {
        public int IdProductStatus { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
    }
}
