using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Infrastructure.Specifications;

namespace MMD_ECommerce.Infrastructure.Repositories.Abstractions
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : ModelKey<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpecification<TEntity> specification);

        Task<int> GetCountWithSpecsAsync(ISpecification<TEntity> specification);

        Task<TEntity> GetAsync(TKey id);

        Task<TEntity> GetWithSpecsAsync(ISpecification<TEntity> specification);

        Task AddAsync(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        void Detach(TEntity entity); // Add this method
        IQueryable<TEntity> AsNoTracking();
    }
}
