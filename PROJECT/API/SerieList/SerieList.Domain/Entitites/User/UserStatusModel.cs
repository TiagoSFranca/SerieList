using System.Collections.Generic;

namespace SerieList.Domain.Entitites.User
{
    public class UserStatusModel
    {
        public int IdUserStatus { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<UserModel> Users { get; set; }
    }
}
