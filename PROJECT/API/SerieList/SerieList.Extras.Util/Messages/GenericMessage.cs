using System;

namespace SerieList.Extras.Util.Messages
{
    public abstract class GenericMessage
    {
        protected string PluralizedName { get; set; }
        protected string Name { get; set; }

        #region Methods

        public string MethodGetAll { get { return String.Format("Listar {0}", PluralizedName); } }

        public string MethodGet { get { return String.Format("Obter {0}", Name); } }

        public string MethodDelete { get { return String.Format("Excluir {0}", Name); } }

        public string MethodPost { get { return String.Format("Salvar {0}", Name); } }

        public string MethodPut { get { return String.Format("Atualizar {0}", Name); } }

        public string MethodReactivate { get { return String.Format("Reativar {0}", Name); } }

        #endregion

        #region Error

        public string GenericError { get { return "Ocorreu um erro"; } }

        public string ErrorSearch { get { return String.Format("Ocorreu um erro ao buscar {0}", PluralizedName); } }

        public string ErrorDelete { get { return String.Format("Ocorreu um erro ao excluir {0}", Name); } }

        public string ErrorPost { get { return String.Format("Ocorreu um erro ao salvar {0}", Name); } }

        public string ErrorPut { get { return String.Format("Ocorreu um erro ao atualizar {0}", Name); } }

        public string ErrorReactivate { get { return String.Format("Ocorreu um erro ao reativar {0}", Name); } }

        #endregion

        #region Success

        public string GenericSuccess { get { return "Operação realizada com sucesso"; } }

        public string SuccessSearch { get { return String.Format("Busca de {0} realizada com sucesso", PluralizedName); } }

        public string SuccessDelete { get { return String.Format("Exclusão de {0} realizada com sucesso", Name); } }

        public string SuccessPost { get { return String.Format("Cadastro de {0} realizado com sucesso", Name); } }

        public string SuccessPut { get { return String.Format("Atuaização de {0} realizada com sucesso", Name); } }

        public string SuccessReactivate { get { return String.Format("Reativação de {0} realizada com sucesso", Name); } }

        #endregion
    }
}
