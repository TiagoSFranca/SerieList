namespace SerieList.Domain.Interfaces
{
    public interface IAssociation<TEntity> where TEntity : class
    {
        TEntity AssociationExcluded(bool excluded);
    }
}
