using SerieList.Application.AppModels.Product;
using System;

namespace SerieList.Application.AppModels.User
{
    public class UserProductAppModel
    {
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public int IdUserProductStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual UserSimplifiedAppModel User { get; set; }
        public virtual ProductAppModel Product { get; set; }
        public virtual UserProductStatusAppModel UserProductStatus { get; set; }
    }
}
