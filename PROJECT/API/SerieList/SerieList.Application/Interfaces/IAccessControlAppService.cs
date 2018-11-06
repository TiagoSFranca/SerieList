using SerieList.Application.AppModels.User;

namespace SerieList.Application.Interfaces
{
    public interface IAccessControlAppService
    {
        void Register(UserAppModel obj, int idApplicationType);

        bool EmailExists(string email);

        bool UserNameExists(string username);

        string ValidatePassword(string password);

        string ValidateUserName(string userName);

        string ValidateEmail(string email);

        void ConfirmMail(string token);

        string Authenticate(string login, string password, bool keep, int applicationType);

        void Unauthenticate(string token);

        void ForgotPassword(string email, int idApplicationType);

        void ResetPassword(string token, string newPassword, string confirmPassword);

        bool ValidToken(string token);

        UserAppModel GetUserByToken(string token);
    }
}
