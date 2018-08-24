using System;

namespace SerieList.Extras.Util.Messages.User
{
    public class UserMessage : GenericMessage
    {
        public UserMessage()
        {
            this.PluralizedName = "Usuários";
            this.Name = "Usuário";
        }
    }
}
