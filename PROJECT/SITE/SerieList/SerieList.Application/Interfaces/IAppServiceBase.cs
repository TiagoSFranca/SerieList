namespace SerieList.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj, string token);

        void Update(TEntity obj, string token);

        TEntity GetById(int id);

        void Remove(int id, string token);
    }
}
