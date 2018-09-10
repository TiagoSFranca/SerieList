using System.Collections.Generic;

namespace SerieList.Domain.Interfaces.Repositories
{
    public interface IQueryRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> AssociationExcluded(bool excluded);
    }
}
