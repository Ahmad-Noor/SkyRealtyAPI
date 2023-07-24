using Sky.Domain.Base;
using System.Linq.Expressions;  
using Microsoft.EntityFrameworkCore;

namespace Sky.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(SkyDBContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T?> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }

        public Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }

        public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToListAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }


        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _dbSet.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T?>> GetAllAsync<TProperty>(Expression<Func<T, TProperty>> include)
        {
            IQueryable<T> query = _dbSet.Include(include);
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate).ConfigureAwait(false);
        }
         
    }
}