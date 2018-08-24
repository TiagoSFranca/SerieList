namespace SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages
{
    public class AccessControlServiceMessage : GenericMessageService
    {
        public AccessControlServiceMessage()
        {
            this.Name = "Controle de Acesso";
        }

        public string EmailExists(string email)
        {
            return string.Format("Email [{0}] já cadastrado.", email);
        }

        public string UserNameExists(string username)
        {
            return string.Format("Usuário [{0}] já cadastrado.", username);
        }

        public string PasswordInvalidLength(int length)
        {
            return string.Format("O tamanho mínimo da senha é [{0}] caracteres.", length);
        }

        public string LoginInvalid { get { return "Usuário ou senha inválidos."; } }

        public string PasswordError{ get { return "Senhas não coincidem."; } }

        public string PasswordHasUsed { get { return "Senha já foi utilizada em outro momento."; } }
    }
}
