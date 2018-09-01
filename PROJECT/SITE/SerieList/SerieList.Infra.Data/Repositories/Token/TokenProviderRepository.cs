using SerieList.Domain.Entitites.Token;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Infra.Data.Data.Context;

namespace SerieList.Infra.Data.Repositories.Token
{
    public class TokenProviderRepository : RepositoryBase<TokenProviderModel>, ITokenProviderRepository
    {
        public TokenProviderRepository(SerieListContext context)
            : base(context)
        {
        }
    }
}
