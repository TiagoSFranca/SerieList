using SerieList.Domain.Mail.Interfaces;
using System;
using SerieList.Domain.Mail.Entities;
using System.Net.Mail;
using System.Net;
using SerieList.Domain.Interfaces.Services;
using SerieList.Domain.Seed;
using System.Collections.Generic;
using System.Net.Mime;
using System.IO;
using SerieList.Extras.Util.Crypt;

namespace SerieList.Domain.Mail.Services
{
    public class MailService : IMailService
    {
        private IConfigurationService _configService;

        protected int SMTPPort { get; set; }
        protected string SMTPHost { get; set; }
        protected string SMTPMail { get; set; }
        protected string SMTPPassword { get; set; }
        protected string SMTPDisplayName { get; set; }

        public MailService(IConfigurationService configService)
        {
            _configService = configService;

            SMTPHost = _configService.GetValueByKey(ConfigurationSeed.SMTPHost.Key);
            string port = _configService.GetValueByKey(ConfigurationSeed.SMTPPort.Key);
            SMTPMail = _configService.GetValueByKey(ConfigurationSeed.SMTPMail.Key);
            SMTPPassword = _configService.GetValueByKey(ConfigurationSeed.SMTPPassword.Key);
            SMTPDisplayName = _configService.GetValueByKey(ConfigurationSeed.SMTPDisplayName.Key);
            SMTPPassword = MD5Crypt.Decrypt(SMTPPassword);
            int portTemp;
            Int32.TryParse(port, out portTemp);
            SMTPPort = portTemp;
        }

        public void SendMultipleDestinationMail(MultipleDestinationMailModel mail)
        {
            SendMail(mail.Body, mail.Subject, mail.Destinations);
        }

        public void SendSingleDestinationMail(SingleDestinationMailModel mail)
        {
            SendMail(mail.Body, mail.Subject, new List<string>() { mail.Destination });
        }

        private void AddDestinations(MailMessage mailMessage, List<string> destinations)
        {
            foreach (var item in destinations)
            {
                mailMessage.To.Add(new MailAddress(item));
            }
        }

        private void SendMail(string body, string subject, List<string> destinations)
        {
            SmtpClient client = new SmtpClient(SMTPHost, SMTPPort);

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            NetworkCredential credential = new NetworkCredential(SMTPMail, SMTPPassword);
            client.Credentials = credential;

            MailAddress mailFrom = new MailAddress(SMTPMail, SMTPDisplayName, System.Text.Encoding.UTF8);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = mailFrom;

            AddDestinations(mailMessage, destinations);
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            AddLogo(mailMessage);
            client.SendAsync(mailMessage, Guid.NewGuid().ToString());
        }

        public void AddLogo(MailMessage message)
        {
            string attachmentPath = AppDomain.CurrentDomain.RelativeSearchPath + @"\Mail\MailTemplate\img\logo.png";
            Attachment inline = new Attachment(attachmentPath);
            inline.ContentDisposition.Inline = true;
            inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
            inline.ContentId = "Logo";
            inline.ContentType.MediaType = "image/png";
            inline.ContentType.Name = Path.GetFileName(attachmentPath);

            message.Attachments.Add(inline);
        }
    }
}
