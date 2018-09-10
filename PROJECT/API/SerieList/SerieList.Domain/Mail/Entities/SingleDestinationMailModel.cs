namespace SerieList.Domain.Mail.Entities
{
    public class SingleDestinationMailModel : MailModel
    {
        public SingleDestinationMailModel(string destination)
        {
            Destination = destination;
        }

        public string Destination { get; set; }
    }
}
