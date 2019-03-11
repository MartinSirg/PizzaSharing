using Contracts.DAL.Base.Repositories;

namespace Contracts.DAL.Base.Helpers
{
    public interface IRepositoryProvider
    {
        /// <summary>
        /// Return TRepository from cache or call factory to create it
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <returns></returns>
        TRepository GetRepository<TRepository>();

        /// <summary>
        /// Return IBaseRepository from cache or create
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IBaseRepositoryAsync<TEntity> GetRepositoryForEntity<TEntity>() 
            where TEntity : class, IBaseEntity, new();
    }
}