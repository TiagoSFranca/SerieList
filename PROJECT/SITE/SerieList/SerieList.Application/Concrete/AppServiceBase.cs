using SerieList.Domain.Interfaces.Services;
using System;
using log4net;
using System.Reflection;
using SerieList.Domain.Entitites.Token;
using SerieList.Infra.Data.CrossCutting.Exceptions.AppServiceException;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.AppServiceMessages.Token;
using SerieList.Extras.Util.Crypt;
using SerieList.Domain.Interfaces.Services.Token;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Seed;

namespace SerieList.Application.Concrete
{
    public class AppServiceBase<TEntity> : IDisposable where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;
        private readonly ITokenProviderService _tokenProviderService;

        private readonly TokenProviderAppServiceMessage tokenProviderAppServiceMessage;

        protected readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public AppServiceBase(IServiceBase<TEntity> serviceBase, ITokenProviderService tokenProviderService)
        {
            _serviceBase = serviceBase;
            _tokenProviderService = tokenProviderService;
            tokenProviderAppServiceMessage = new TokenProviderAppServiceMessage();
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        protected void LogExceptions(Exception exceptionThrown)
        {
            logger.Error(exceptionThrown.Message, exceptionThrown);
        }

        protected TokenProviderModel ValidateToken(string token)
        {
            var tokenUser = GetTokenUser(token);
            var tokenProvider = _tokenProviderService.GetByToken(token);

            if (tokenProvider == null)
                throw new AppServiceException(tokenProviderAppServiceMessage.TokenNotFound);
            tokenProvider.Validate(tokenUser.KeepConnected);

            return tokenProvider;
        }

        private TokenUserModel GetTokenUser(string token)
        {
            TokenUserModel tokenUser = null;
            try
            {
                tokenUser = TokenCrypt.GetTokenUserModel(token);
                return tokenUser;
            }
            catch (Exception e)
            {
            }

            if (tokenUser == null)
                throw new AppServiceException(tokenProviderAppServiceMessage.TokenNotFound);

            return tokenUser;
        }
    }
}
