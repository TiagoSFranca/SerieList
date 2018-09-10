using SerieList.Domain.Entitites.Token;
using SerieList.Domain.Entitites.User;

namespace SerieList.Domain.Interfaces.Services
{
    public interface IAccessControlService
    {
        string Register(UserModel user);

        bool EmailExists(string email);

        bool UserNameExists(string username);

        string ValidatePassword(string password);

        string ValidateUserName(string userName);

        string ValidateEmail(string email);

        void ConfirmMail(string token);

        string Authenticate(string username, string password, bool keep);

        void Authorize(UserModel user, int idPermission);

        void Unauthenticate(string token);

        string ForgotPassword(string email);

        void ResetPassword(TokenProviderModel tokenProvider, string newPassword, string confirmPassword);
    }
}
