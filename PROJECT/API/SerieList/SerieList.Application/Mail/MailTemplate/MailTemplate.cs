using SerieList.Application.Mail.Interfaces;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Seed;
using System;
using System.IO;

namespace SerieList.Application.Mail.MailTemplate
{
    public class MailTemplate : IMailTemplate
    {
        private const string PATHSTYLESHEET = "Mail/MailTemplate/css/MailTemplate.css";
        private const string PATHMAILTEMPLATE = "Mail/MailTemplate/html/MailTemplate.html";
        private const string PATHFOOTERTEMPLATE = "Mail/MailTemplate/html/FooterTemplate.html";
        private const string PATHREGISTERTEMPLATE = "Mail/MailTemplate/html/RegisterTemplate.html";
        private const string PATHFORGOTPASSWORDTEMPLATE = "Mail/MailTemplate/html/ForgotPasswordTemplate.html";

        private string BasePath { get { return AppDomain.CurrentDomain.RelativeSearchPath; } }

        private readonly IConfigurationService _configService;

        public MailTemplate(IConfigurationService configService)
        {
            _configService = configService;
        }

        public string GetRegisterTemplate(string firstName, string userName, string confirmationCodeEncoded)
        {
            var template = GetMailTemplate();
            var sheet = GetStyleSheet();
            var footer = GetGeneralFooter();

            var mailTitle = _configService.GetValueByKey(ConfigurationSeed.MailTitleRegister.Key);

            template = template.Replace(GetKey("TITLE"), mailTitle);
            template = template.Replace(GetKey("CSS"), sheet);
            template = template.Replace(GetKey("FOOTER"), footer);

            var content = GetTemplate(PATHREGISTERTEMPLATE);
            content = content.Replace(GetKey("FIRST_NAME"), firstName);
            content = content.Replace(GetKey("USERNAME"), userName);

            var confirmMailRoute = _configService.GetValueByKey(ConfigurationSeed.ConfirmMailRoute.Key);
            confirmMailRoute = string.Format("{0}?code={1}", confirmMailRoute, confirmationCodeEncoded);

            content = content.Replace(GetKey("CONFIRMATION_CODE"), confirmMailRoute.ToString());

            template = template.Replace(GetKey("CONTENT"), content);

            return template;
        }

        private string GetKey(string key)
        {
            return string.Format("([{0}])", key);
        }

        private string GetMailTemplate()
        {
            return GetTemplate(PATHMAILTEMPLATE);
        }

        private string GetTemplate(string pathTemplate)
        {
            string template = string.Empty;
            var path = Path.Combine(BasePath, pathTemplate);
            if (File.Exists(path))
                template = File.ReadAllText(path);
            return template;
        }

        private string GetStyleSheet()
        {
            return GetTemplate(PATHSTYLESHEET);
        }

        private string GetGeneralFooter()
        {
            string footer = GetTemplate(PATHFOOTERTEMPLATE);

            var siteName = _configService.GetValueByKey(ConfigurationSeed.SiteName.Key);
            var siteRoute = _configService.GetValueByKey(ConfigurationSeed.SiteRoute.Key);
            var siteCopyriting = _configService.GetValueByKey(ConfigurationSeed.SiteCopyriting.Key);

            footer = footer.Replace(GetKey("SITE_NAME"), siteName);
            footer = footer.Replace(GetKey("SITE_ROUTE"), siteRoute);
            footer = footer.Replace(GetKey("SITE_COPYRITING"), siteCopyriting);

            return footer;
        }

        public string GetForgotPasswordTemplate(string firstName, string tokenEncoded)
        {
            var template = GetMailTemplate();
            var sheet = GetStyleSheet();
            var footer = GetGeneralFooter();

            var mailTitle = _configService.GetValueByKey(ConfigurationSeed.MailTitleForgotPassword.Key);

            template = template.Replace(GetKey("TITLE"), mailTitle);
            template = template.Replace(GetKey("CSS"), sheet);
            template = template.Replace(GetKey("FOOTER"), footer);

            var content = GetTemplate(PATHFORGOTPASSWORDTEMPLATE);
            content = content.Replace(GetKey("FIRST_NAME"), firstName);

            var forgotPasswordRoute = _configService.GetValueByKey(ConfigurationSeed.ForgotPasswordRoute.Key);
            forgotPasswordRoute = string.Format("{0}?code={1}", forgotPasswordRoute, tokenEncoded);

            content = content.Replace(GetKey("RESET_CODE"), forgotPasswordRoute);

            template = template.Replace(GetKey("CONTENT"), content);

            return template;
        }
    }
}
