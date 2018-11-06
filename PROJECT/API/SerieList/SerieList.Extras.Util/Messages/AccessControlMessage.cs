using System;

namespace SerieList.Extras.Util.Messages
{
    public class AccessControlMessage : GenericMessage
    {
        public AccessControlMessage()
        {
            this.PluralizedName = "Controle de Acesso";
            this.Name = "Controle de Acesso";
        }


        public string MethodRegister { get { return String.Format("Registrar Usuário"); } }
        public string MethodConfirmMail { get { return String.Format("Confirmar Email"); } }
        public string MethodAuthenticate { get { return String.Format("Autenticação"); } }
        public string MethodUnuthenticate { get { return String.Format("Cancelar Autenticação"); } }
        public string MethodForgotPassword { get { return String.Format("Esqueceu a senha"); } }
        public string MethodResetPassword { get { return String.Format("Redefinição da senha"); } }
        public string MethodValidToken { get { return String.Format("Validação de Token"); } }
        public string MethodUserByToken { get { return String.Format("Obter Usuário via Token"); } }

        public string SuccessRegister { get { return String.Format("Registro de Usuário realizado com sucesso"); } }
        public string SuccessConfirmMail { get { return String.Format("Confirmação de email realizado com sucesso"); } }
        public string SuccessAuthenticate { get { return String.Format("Autenticação realizada com sucesso"); } }
        public string SuccessUnauthenticate { get { return String.Format("Autenticação cancelada com sucesso"); } }
        public string SuccessForgotPassword { get { return String.Format("Envio de email de redefinição de senha realizado com sucesso"); } }
        public string SuccessResetPassword { get { return String.Format("Redefinição de senha realizada com sucesso"); } }
        public string SuccessValidToken { get { return String.Format("Token validado com sucesso"); } }
        public string SuccessUserByToken { get { return String.Format("Usuário obtido com sucesso"); } }

        public string ErrorRegister { get { return String.Format("Ocorreu um erro ao registrar usuário"); } }
        public string ErrorConfirmMail { get { return String.Format("Ocorreu um erro ao confirmar email"); } }
        public string ErrorAuthenticate { get { return String.Format("Ocorreu um erro ao autenticar"); } }
        public string ErrorUnauthenticate { get { return String.Format("Ocorreu um erro ao cancelar autenticação"); } }
        public string ErrorForgotPassword { get { return String.Format("Erro ao enviar email de redefinição de senha"); } }
        public string ErrorResetPassword { get { return String.Format("Erro ao redefinir senha"); } }
        public string ErrorValidToken { get { return String.Format("Ocorreu um erro ao validar token"); } }
        public string ErrorUserByToken { get { return String.Format("Ocorreu um erro ao buscar o usuário"); } }
    }
}
