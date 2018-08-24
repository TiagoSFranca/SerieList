namespace SerieList.Application.Mail.Interfaces
{
    public interface IMailTemplate
    {
        string GetRegisterTemplate(string firstName, string userName, string confirmationCodeEncrypted);
        string GetForgotPasswordTemplate(string firstName, string tokenEncrypted);
    }
}
