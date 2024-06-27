using MMD_ECommerce.Data.Bases;

namespace MMD_ECommerce.Infrastructure.Repositories.Abstractions
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : ModelKey<TKey>;

        Task<int> CompleteAsync();


    }
}
