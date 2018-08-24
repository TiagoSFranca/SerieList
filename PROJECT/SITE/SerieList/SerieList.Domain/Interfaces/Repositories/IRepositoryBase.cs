using System.Linq;

namespace SerieList.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        TEntity GetById(int id, bool detached = false);

        void Remove(TEntity obj);

        void Dispose();

        IQueryable<TEntity> Query();
    }
}
