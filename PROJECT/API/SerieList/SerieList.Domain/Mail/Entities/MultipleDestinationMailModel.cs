using System.Collections.Generic;

namespace SerieList.Domain.Mail.Entities
{
    public class MultipleDestinationMailModel : MailModel
    {
        public MultipleDestinationMailModel(List<string> destinations)
        {
            Destinations = destinations;
        }

        public List<string> Destinations { get; set; }
    }
}
