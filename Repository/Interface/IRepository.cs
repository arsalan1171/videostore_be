using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task<T> UpdateAsync(int id, T entity);
    Task<IEnumerable<T>> GetByNameAsync(string searchTerm);
}
