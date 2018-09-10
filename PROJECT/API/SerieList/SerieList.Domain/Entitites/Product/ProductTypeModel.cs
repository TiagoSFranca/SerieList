using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Product
{
    public partial class ProductTypeModel
    {
        public int IdProductType { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
    }
}
