namespace SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User
{
    public class UserProductServiceMessage : GenericMessageService
    {
        public UserProductServiceMessage()
        {
            this.Name = "Produtos do Usuário";
        }
    }
}
