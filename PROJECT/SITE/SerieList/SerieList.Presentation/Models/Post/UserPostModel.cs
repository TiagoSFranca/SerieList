namespace SerieList.Presentation.Models.Post
{
    public class UserPostModel
    {
    }

    public class UserRegisterModel
    {
        public int IdProfile { get; set; }
        public int IdUserStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }

    public class UserLoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool KeepConnected { get; set; }
    }

    public class ResetPasswordModel
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}