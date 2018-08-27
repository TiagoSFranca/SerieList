using SerieList.Domain.Interfaces.Repositories;
using SerieList.Domain.Interfaces.Repositories.Token;
using SerieList.Domain.Interfaces.Services;
using System;
using SerieList.Domain.Entitites.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages;
using System.Linq;
using SerieList.Domain.CommonEntities;
using SerieList.Domain.Seed;
using System.Collections.Generic;

namespace SerieList.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly ITokenProviderRepository _tokenProviderRepo;

        private readonly IConfigurationRepository _configurationRepo;

        private GenericMessageService genericMessage;

        public ServiceBase(IRepositoryBase<TEntity> repository, ITokenProviderRepository tokenProviderRepo, IConfigurationRepository configurationRepo)
        {
            _repository = repository;
            _tokenProviderRepo = tokenProviderRepo;
            _configurationRepo = configurationRepo;
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

        protected PagingResultModel<TEntity> Paginate(IQueryable<TEntity> query, PagingModel paging)
        {
            return Paginate(query.ToList(), paging);
        }

        protected PagingResultModel<TEntity> Paginate(IEnumerable<TEntity> query, PagingModel paging)
        {
            var pagingModel = GetPagingModel(paging.ActualPage, paging.ItemsPerPage);
            var result = new PagingResultModel<TEntity>(paging);
            result.TotalItems = query.Count();
            result.Items = query.Skip((paging.ActualPage == 1 ? 0 : paging.ActualPage - 1) * paging.ItemsPerPage).Take(paging.ItemsPerPage).ToList();
            return result;
        }

        private PagingModel GetPagingModel(int actualPage, int itemsPerPage)
        {
            var minPagination = GetValue(ConfigurationSeed.MinItemsPerPage.Key);
            if (minPagination != null)
            {
                int minItemsPerPage = 0;
                Int32.TryParse(minPagination, out minItemsPerPage);
                if (minItemsPerPage > 0 && itemsPerPage < minItemsPerPage)
                    return new PagingModel(actualPage, minItemsPerPage);
            }

            var maxPagination = GetValue(ConfigurationSeed.MaxItemsPerPage.Key);
            if (maxPagination != null)
            {
                int maxItemsPerPage = 0;
                Int32.TryParse(maxPagination, out maxItemsPerPage);
                if (maxItemsPerPage > 0 && itemsPerPage > maxItemsPerPage)
                    return new PagingModel(actualPage, maxItemsPerPage);
            }

            return new PagingModel(actualPage, itemsPerPage);
        }

        private string GetValue(string key)
        {
            var obj = _configurationRepo.Query().FirstOrDefault(c => c.Key.ToLower().Equals(key.ToLower()));
            if (obj != null)
                return obj.Value;
            return null;
        }
    }
}
