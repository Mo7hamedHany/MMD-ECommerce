using Microsoft.EntityFrameworkCore;
using MMD_ECommerce.Data.Bases;
using MMD_ECommerce.Infrastructure.Data.Contexts;
using MMD_ECommerce.Infrastructure.Repositories.Abstractions;
using MMD_ECommerce.Infrastructure.Specifications;

namespace MMD_ECommerce.Infrastructure.Repositories.Implementations
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : ModelKey<TKey>
    {
        private readonly MMDDataContext _context;

        public GenericRepository(MMDDataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public IQueryable<TEntity> AsNoTracking()
            => _context.Set<TEntity>().AsNoTracking();

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void Detach(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpecification<TEntity> specification) => await ApplySpecifications(specification).ToListAsync();

        public async Task<TEntity> GetAsync(TKey id) => (await _context.Set<TEntity>().FindAsync(id))!;

        public async Task<int> GetCountWithSpecsAsync(ISpecification<TEntity> specification) => await ApplySpecifications(specification).CountAsync();


        public async Task<TEntity> GetWithSpecsAsync(ISpecification<TEntity> specification) => (await ApplySpecifications(specification).FirstOrDefaultAsync())!;

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);


        private IQueryable<TEntity> ApplySpecifications(ISpecification<TEntity> specification)
        {
            return SpecificationEvaluator<TEntity, TKey>.BuildQuery(_context.Set<TEntity>(), specification);
        }
    }
}
