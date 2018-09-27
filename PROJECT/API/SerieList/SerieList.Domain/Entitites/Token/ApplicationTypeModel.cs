using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Token
{
    public class ApplicationTypeModel
    {
        public int IdApplicationType { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<TokenProviderModel> TokenProviders { get; set; }
    }
}
