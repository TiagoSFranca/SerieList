using SerieList.Domain.Mail.Entities;

namespace SerieList.Domain.Mail.Interfaces
{
    public interface IMailService
    {
        void SendSingleDestinationMail(SingleDestinationMailModel mail);

        void SendMultipleDestinationMail(MultipleDestinationMailModel mail);
    }
}
