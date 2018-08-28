namespace SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User
{
    public class UserServiceMessage : GenericMessageService
    {
        public UserServiceMessage()
        {
            this.Name = "Usuário";
        }

        public string MailNotConfirmed { get { return "Email não confirmado."; } }
    }
}
