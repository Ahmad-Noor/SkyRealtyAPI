using System.Linq.Expressions;

namespace Sky.Domain.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<T?> GetAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);

         
        Task<T?> GetByIdAsync(object id); 
        Task<IEnumerable<T?>> GetAllAsync();
        Task<IEnumerable<T?>> GetAllAsync<TProperty>(Expression<Func<T, TProperty>> include);
        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
