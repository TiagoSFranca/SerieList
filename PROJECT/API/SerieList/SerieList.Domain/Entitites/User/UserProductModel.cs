using SerieList.Domain.Entitites.Product;
using System;

namespace SerieList.Domain.Entitites.User
{
    public partial class UserProductModel
    {
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public int IdUserProductStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual UserModel User { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual UserProductStatusModel UserProductStatus { get; set; }

    }
}
