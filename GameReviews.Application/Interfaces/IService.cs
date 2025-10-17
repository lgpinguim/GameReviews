using System.Linq.Expressions;

namespace GameReviews.Application.Interfaces;

public interface IService<TEntity, TDto>
    where TEntity : class
    where TDto : class
{
    // Queries
    Task<TDto?> GetByIdAsync(int id);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<IEnumerable<TDto>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    // Commands
    Task<TDto> CreateAsync(TDto dto);
    Task UpdateAsync(int id, TDto dto);
    Task DeleteAsync(int id);
}