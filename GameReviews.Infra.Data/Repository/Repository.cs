using System.Linq.Expressions;
using GameReviews.Domain.Interfaces;
using GameReviews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GameReviews.Infra.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly GameReviewsContext Db;
    protected readonly DbSet<T> DbSet;

    public Repository(GameReviewsContext db)
    {
        Db = db;
        DbSet = db.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    //Todo: Add pagination
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public async Task DeleteAsync(int id)
    {
        T? entity = await GetByIdAsync(id);

        if (entity is null)
        {
            throw new KeyNotFoundException($"Entity with id {id} not found.");
        }

        DbSet.Remove(entity);
    }

    public Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return Task.CompletedTask;
    }
}