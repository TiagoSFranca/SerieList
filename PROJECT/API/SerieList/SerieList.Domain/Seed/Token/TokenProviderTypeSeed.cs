using SerieList.Domain.Entitites.Token;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Token
{
    public class TokenProviderTypeSeed
    {
        public static TokenProviderTypeModel ResetPassword { get { return new TokenProviderTypeModel() { IdTokenProviderType = 1, Description = "Redefinição de senha", HoursValid = 12, Excluded = false }; } }
        public static TokenProviderTypeModel ConfirmEmail { get { return new TokenProviderTypeModel() { IdTokenProviderType = 2, Description = "Confirmação de Email", HoursValid = 12, Excluded = false }; } }
        public static TokenProviderTypeModel Authentication { get { return new TokenProviderTypeModel() { IdTokenProviderType = 3, Description = "Login", HoursValid = 4, Excluded = false }; } }

        public static List<TokenProviderTypeModel> Seeds
        {
            get
            {
                return new List<TokenProviderTypeModel>()
                {
                    ResetPassword,
                    ConfirmEmail,
                    Authentication
                };
            }
        }
    }
}
