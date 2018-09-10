using SerieList.Domain.Entitites;
using System.Collections.Generic;
using SerieList.Extras.Util.Crypt;

namespace SerieList.Domain.Seed
{
    public class ConfigurationSeed
    {
        public static ConfigurationModel MinPasswordLength { get { return new ConfigurationModel() { IdConfiguration = 1, Key = "MinPasswordLength", Value = "8", Excluded = false }; } }
        public static ConfigurationModel SMTPPassword { get { return new ConfigurationModel() { IdConfiguration = 2, Key = "SMTPPassword", Value = MD5Crypt.Encrypt("Tiago#91513062"), Excluded = false }; } }
        public static ConfigurationModel SMTPHost { get { return new ConfigurationModel() { IdConfiguration = 3, Key = "SMTPHost", Value = "smtp.gmail.com", Excluded = false }; } }
        public static ConfigurationModel SMTPPort { get { return new ConfigurationModel() { IdConfiguration = 4, Key = "SMTPPort", Value = 587.ToString(), Excluded = false }; } }
        public static ConfigurationModel SMTPMail { get { return new ConfigurationModel() { IdConfiguration = 5, Key = "SMTPMail", Value = "tiago.frantos@gmail.com", Excluded = false }; } }
        public static ConfigurationModel SMTPDisplayName { get { return new ConfigurationModel() { IdConfiguration = 6, Key = "SMTPDisplayName", Value = "PROJETO", Excluded = false }; } }
        public static ConfigurationModel SiteName { get { return new ConfigurationModel() { IdConfiguration = 7, Key = "SiteName", Value = "PROJETO", Excluded = false }; } }
        public static ConfigurationModel SiteRoute { get { return new ConfigurationModel() { IdConfiguration = 8, Key = "SiteRoute", Value = "http://localhost:49812/", Excluded = false }; } }
        public static ConfigurationModel SiteCopyriting { get { return new ConfigurationModel() { IdConfiguration = 9, Key = "SiteCopyriting", Value = "© Copyright 2018", Excluded = false }; } }
        public static ConfigurationModel MailTitleRegister { get { return new ConfigurationModel() { IdConfiguration = 10, Key = "MailTitleRegister", Value = "Registro de Novo Usuário", Excluded = false }; } }
        public static ConfigurationModel ConfirmMailRoute { get { return new ConfigurationModel() { IdConfiguration = 11, Key = "ConfirmMailRoute", Value = "http://localhost:49812/api/AccessControl/ConfirmMail/", Excluded = false }; } }
        public static ConfigurationModel MailTitleForgotPassword { get { return new ConfigurationModel() { IdConfiguration = 12, Key = "MailTitleForgotPassword", Value = "Redefinir Senha", Excluded = false }; } }
        public static ConfigurationModel ForgotPasswordRoute { get { return new ConfigurationModel() { IdConfiguration = 13, Key = "ForgotPasswordRoute", Value = "http://localhost:49812/api/AccessControl/ResetPassword/", Excluded = false }; } }
        public static ConfigurationModel MaxItemsPerPage { get { return new ConfigurationModel() { IdConfiguration = 14, Key = "MaxItemsPerPage", Value = "60", Excluded = false }; } }
        public static ConfigurationModel MinItemsPerPage { get { return new ConfigurationModel() { IdConfiguration = 15, Key = "MinItemsPerPage", Value = "10", Excluded = false }; } }

        public static List<ConfigurationModel> Seeds
        {
            get
            {
                return new List<ConfigurationModel>()
                {
                    MinPasswordLength,
                    SMTPPassword,
                    SMTPHost,
                    SMTPPort,
                    SMTPMail,
                    SMTPDisplayName,
                    SiteName,
                    SiteRoute,
                    SiteCopyriting,
                    MailTitleRegister,
                    ConfirmMailRoute,
                    MailTitleForgotPassword,
                    ForgotPasswordRoute,
                    MaxItemsPerPage,
                    MinItemsPerPage
                };
            }
        }
    }
}
