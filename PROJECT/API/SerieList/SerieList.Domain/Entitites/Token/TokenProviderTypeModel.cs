using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Token
{
    public partial class TokenProviderTypeModel
    {
        public int IdTokenProviderType { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }
        public int HoursValid { get; set; }

        public virtual ICollection<TokenProviderModel> TokenProviders { get; set; }
    }
}
