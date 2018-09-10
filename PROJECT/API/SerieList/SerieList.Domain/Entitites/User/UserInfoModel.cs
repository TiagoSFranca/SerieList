using System;

namespace SerieList.Domain.Entitites.User
{
    public partial class UserInfoModel
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int AccessFaliedCount { get; set; }

        public virtual UserModel User { get; set; }

    }
}
