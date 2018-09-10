using System.Collections.Generic;

namespace SerieList.Domain.Entitites.User
{
    public class UserProductStatusModel
    {
        public int IdUserProductStatus { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<UserProductModel> UserProducts { get; set; }
    }
}
