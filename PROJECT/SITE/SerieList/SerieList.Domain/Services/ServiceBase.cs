using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services;
using System;
using SerieList.Domain.Entitites.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages;

namespace SerieList.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private GenericMessageService genericMessage;

        public ServiceBase(IRepositoryBase<TEntity> repository, ITokenProviderRepository tokenProviderRepo)
        {
            _repository = repository;
            _tokenProviderRepo = tokenProviderRepo;
            genericMessage = new GenericMessageService();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
        
        public void Add(TEntity obj, UserModel userCredentials)
        {
            throw new ServiceException(genericMessage.NotImplemented);
        }

        public void Update(TEntity obj, UserModel userCredentials)
        {
            throw new ServiceException(genericMessage.NotImplemented);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity obj, UserModel userCredentials)
        {
            throw new ServiceException(genericMessage.NotImplemented);
        }
    }
}
