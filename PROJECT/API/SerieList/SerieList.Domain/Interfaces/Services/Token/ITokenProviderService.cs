using SerieList.Domain.Entitites.Token;
using SerieList.Domain.Entitites.User;

namespace SerieList.Domain.Interfaces.Services.Token
{
    public interface ITokenProviderService : IServiceBase<TokenProviderModel>
    {
        string CreateToken(int tokenType, int idApplicationType, UserModel user = null, bool? keep = null);

        TokenProviderModel GetByToken(string token);
    }
}
