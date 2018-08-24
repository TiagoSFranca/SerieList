using SerieList.Domain.Entitites.User;

namespace SerieList.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj, UserModel userCredentials);

        void Update(TEntity obj, UserModel userCredentials);

        TEntity GetById(int id);

        void Remove(TEntity obj, UserModel userCredentials);

        void Dispose();
        
    }
}
