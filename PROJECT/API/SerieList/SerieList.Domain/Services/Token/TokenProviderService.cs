using SerieList.Domain.Entitites.Token;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.Interfaces.Repositories.Token;
using System;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Token;
using SerieList.Extras.Util.Crypt;
using System.Linq;
using SerieList.Domain.Seed.Token;
using SerieList.Domain.Entitites.User;
using SerieList.Domain.Interfaces.Repositories;

namespace SerieList.Domain.Services.Token
{
    public class TokenProviderService : ServiceBase<TokenProviderModel>, ITokenProviderService
    {
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private TokenProviderServiceMessage tokenProviderMessage;

        public TokenProviderService(ITokenProviderRepository tokenProviderRepo, IConfigurationRepository configurationRepo)
            : base(tokenProviderRepo, tokenProviderRepo, configurationRepo)
        {
            _tokenProviderRepo = tokenProviderRepo;
            tokenProviderMessage = new TokenProviderServiceMessage();
        }

        public void Update(TokenProviderModel obj, UserModel userCredentials)
        {
            _tokenProviderRepo.Update(obj);
        }

        private void DisableAllUserTokens(int tokenType, int idUser, int? idToken = null)
        {
            var query = _tokenProviderRepo.Query().Where(
                e => e.IdTokenProviderType == tokenType &&
                e.IdUser == idUser &&
                e.Valid == true &&
                e.Excluded == false);
            if (idToken != null)
                query = query.Where(e => e.IdTokenProvider != idToken);

            var tokens = query.ToList();

            foreach (var item in tokens)
            {
                item.Valid = false;
                _tokenProviderRepo.Update(item);
            }
        }

        public string CreateToken(int tokenType, UserModel user = null, bool? keep = null)
        {
            var token = TokenCrypt.GenerateTokenUser(
                new TokenUserModel()
                {
                    IdUser = user != null ? user.IdUser : 0,
                    SecurityStamp = user?.UserInfo != null ? user.UserInfo.SecurityStamp : string.Empty,
                    KeepConnected = keep != null ? (bool)keep : false,
                    CreatedAt = DateTime.Now
                });

            TokenProviderModel tokenProvider = new TokenProviderModel
            {
                IdUser = user.IdUser,
                IdTokenProviderType = tokenType,
                Valid = true,
                Token = token
            };

            if (user != null && tokenType != TokenProviderTypeSeed.Authentication.IdTokenProviderType)
                DisableAllUserTokens(tokenType, user.IdUser, tokenProvider.IdTokenProvider);

            _tokenProviderRepo.Add(tokenProvider);
            return tokenProvider.Token;
        }

        public TokenProviderModel GetByToken(string token)
        {
            return _tokenProviderRepo.Query().FirstOrDefault(e => e.Token.Equals(token));
        }

    }
}
