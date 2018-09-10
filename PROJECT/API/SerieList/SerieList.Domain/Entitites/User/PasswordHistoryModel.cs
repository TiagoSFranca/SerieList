using System;

namespace SerieList.Domain.Entitites.User
{
    public class PasswordHistoryModel
    {
        public int IdPasswordHistory { get; set; }
        public int IdUser { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual UserModel User { get; set; }
    }
}
