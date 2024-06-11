using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
