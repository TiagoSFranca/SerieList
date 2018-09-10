using System;

namespace SerieList.Application.AppModels.User
{
    public class UserInfoAppModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public string UserName { get; set; }
        public int AccessFaliedCount { get; set; }
    }

    public class UserInfoSimplifiedAppModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
