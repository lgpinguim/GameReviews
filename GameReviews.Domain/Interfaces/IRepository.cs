using System.Linq.Expressions;

namespace GameReviews.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    // Queries
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    // Commands
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task DeleteAsync(T entity);

    // Unit of Work
    Task<int> SaveChangesAsync();
}