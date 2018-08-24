using SerieList.Application.AppModels.User;

namespace SerieList.Application.Interfaces
{
    public interface IAccessControlAppService
    {
        void Register(UserAppModel obj);

        bool EmailExists(string email);

        bool UserNameExists(string username);

        string ValidatePassword(string password);

        void ConfirmMail(string token);

        string Authenticate(string login, string password, bool keep);

        void Unauthenticate(string token);

        void ForgotPassword(string email);

        void ResetPassword(string token, string newPassword, string confirmPassword);
    }
}
