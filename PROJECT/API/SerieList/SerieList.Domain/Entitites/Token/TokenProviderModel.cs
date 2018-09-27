using SerieList.Domain.Entitites.User;
using System;

namespace SerieList.Domain.Entitites.Token
{
    public partial class TokenProviderModel
    {
        public int IdTokenProvider { get; set; }
        public int? IdUser { get; set; }
        public int IdTokenProviderType { get; set; }
        public int IdApplicationType { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Valid { get; set; }
        public bool Excluded { get; set; }

        public virtual UserModel User { get; set; }
        public virtual ApplicationTypeModel ApplicationType { get; set; }
        public virtual TokenProviderTypeModel TokenProviderType { get; set; }

    }
}
