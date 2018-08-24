namespace SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User
{
    public class UserStatusServiceMessage : GenericMessageService
    {
        public UserStatusServiceMessage()
        {
            this.Name = "Situação de Usuário";
        }

        public string HasStatus(string status)
        {
            return string.Format("{0} está {1}", Name, status);
        }
    }
}
