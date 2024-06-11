using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Infrastructure.Data.Contexts;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_ECommerce.Infrastructure.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Hashtable _repositories;
        private readonly MMDDataContext _context;

        public UnitOfWork(MMDDataContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _context.DisposeAsync();


        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : ModelKey<TKey>
        {
            var typeName = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(typeName))
            {
                var repo = new GenericRepository<TEntity, TKey>(_context);
                _repositories.Add(typeName, repo);

                return repo;
            }

            return (_repositories[typeName] as GenericRepository<TEntity, TKey>)!;
        }
    }
}
