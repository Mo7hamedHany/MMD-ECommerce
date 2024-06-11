using MMD_ECommerce.Data.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Infrastructure.Repositories.Abstractions
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : ModelKey<TKey>;

        Task<int> CompleteAsync();
    }
}
