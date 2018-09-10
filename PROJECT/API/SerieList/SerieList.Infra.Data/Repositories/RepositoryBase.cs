using SerieList.Domain.Interfaces.Repositories;
using SerieList.Infra.Data.Data.Context;
using System;
using System.Data.Entity;
using System.Linq;

namespace SerieList.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected SerieListContext _context;

        public RepositoryBase(SerieListContext context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public TEntity GetById(int id, bool detached = false)
        {
            var element = _context.Set<TEntity>().Find(id);
            if (detached && element != null)
                _context.Entry(element).State = EntityState.Detached;
            return element;

        }

        public void Remove(TEntity obj)
        {
            if (!_context.Set<TEntity>().Local.Any(e => e == obj))
                _context.Set<TEntity>().Attach(obj);
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

    }
}

