namespace SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Token
{
    public class TokenProviderServiceMessage : GenericMessageService
    {
        public TokenProviderServiceMessage()
        {
            this.Name = "Token Provider";
        }

        public string TokenNotFound { get { return "Token não encontrado"; } }
        public string TokenExpired { get { return "Token expirado"; } }
        public string TokenInvalid { get { return "Token inválido"; } }
        public string ApplicationTypeInvalid { get { return "Tipo de aplicação inválido"; } }

    }
}
