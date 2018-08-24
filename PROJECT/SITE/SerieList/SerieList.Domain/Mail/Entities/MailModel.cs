namespace SerieList.Domain.Mail.Entities
{
    public abstract class MailModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
