using GameReviews.Domain.Interfaces;
using GameReviews.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace GameReviews.Infra.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly GameReviewsContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(GameReviewsContext context)
    {
        _context = context;

        // Initialize repositories
        Achievements = new AchievementRepository(_context);
        Categories = new CategoryRepository(_context);
        Developers = new DeveloperRepository(_context);
        Games = new GameRepository(_context);
        LanguageSupports = new LanguageSupportRepository(_context);
        Platforms = new PlatformRepository(_context);
        Publishers = new PublisherRepository(_context);
        Reviews = new ReviewRepository(_context);
        Users = new UserRepository(_context);
    }

    public IAchievementRepository Achievements { get; }
    public ICategoryRepository Categories { get; }
    public IDeveloperRepository Developers { get; }
    public IGameRepository Games { get; }
    public ILanguageSupportRepository LanguageSupports { get; }
    public IPlatformRepository Platforms { get; }
    public IPublisherRepository Publishers { get; }
    public IReviewRepository Reviews { get; }
    public IUserRepository Users { get; }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}