using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Token;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System;

namespace SerieList.Domain.Entitites.Token
{
    partial class TokenProviderModel
    {
        public void Validate(bool? keep = null)
        {
            TokenProviderServiceMessage tokenProviderMessage = new TokenProviderServiceMessage();
            if (keep != null && !(bool)keep)
                if (CreatedAt.AddHours(TokenProviderType.HoursValid) < DateTime.Now)
                    throw new ServiceException(tokenProviderMessage.TokenExpired);
            if (!Valid || Excluded)
                throw new ServiceException(tokenProviderMessage.TokenInvalid);
        }
    }
}
