namespace GameReviews.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Repository properties
    IAchievementRepository Achievements { get; }
    ICategoryRepository Categories { get; }
    IDeveloperRepository Developers { get; }
    IGameRepository Games { get; }
    ILanguageSupportRepository LanguageSupports { get; }
    IPlatformRepository Platforms { get; }
    IPublisherRepository Publishers { get; }
    IReviewRepository Reviews { get; }
    IUserRepository Users { get; }

    // Transaction methods
    Task<int> CommitAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}