using SerieList.Domain.Entitites.Token;
using SerieList.Domain.Entitites.User;

namespace SerieList.Domain.Interfaces.Services
{
    public interface IAccessControlService
    {
        string Register(UserModel user, int idApplicationType);

        bool EmailExists(string email);

        bool UserNameExists(string username);

        string ValidatePassword(string password);

        string ValidateUserName(string userName);

        string ValidateEmail(string email);

        void ConfirmMail(string token);

        string Authenticate(string username, string password, bool keep, int idApplicationType);

        void Authorize(UserModel user, int idPermission);

        void Unauthenticate(string token);

        string ForgotPassword(string email, int idApplicationType);

        void ResetPassword(TokenProviderModel tokenProvider, string newPassword, string confirmPassword);
    }
}
