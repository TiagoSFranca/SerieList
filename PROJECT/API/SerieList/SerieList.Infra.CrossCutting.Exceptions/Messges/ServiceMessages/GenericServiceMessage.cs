namespace SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages
{
    public class GenericMessageService
    {
        protected string Name { get; set; }

        public string ElementNotExists(int id)
        {
            return string.Format("Elemento [{0}] de ID [{1}] não encontrado", Name, id);
        }

        public string DescriptionExists { get { return "Descrição já Cadastrada"; } }

        public string NotImplemented { get { return "Método não implementado"; } }

        public string Excluded { get { return string.Format("{0} excluido(a)", Name); } }

        public string Unauthorized { get { return "Acesso não autorizado."; } }

        public string NotFound { get { return string.Format("{0} não encontrado(a)", Name); } }

        public string UserInvalid { get { return "Usuário não pode fazer esta operação."; } }
    }
}
