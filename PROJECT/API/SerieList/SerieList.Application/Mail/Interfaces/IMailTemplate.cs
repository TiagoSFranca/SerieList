namespace SerieList.Application.Mail.Interfaces
{
    public interface IMailTemplate
    {
        string GetRegisterTemplate(string firstName, string userName, string confirmationCodeEncoded);
        string GetForgotPasswordTemplate(string firstName, string tokenEncoded);
    }
}
