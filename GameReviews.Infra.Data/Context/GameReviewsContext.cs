using GameReviews.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace GameReviews.Infra.Data.Context;

public class GameReviewsContext : DbContext
{
    public GameReviewsContext(DbContextOptions<GameReviewsContext> options) : base(options) {}

    public DbSet<Game> Games { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Developer> Developers { get; set; }
    public DbSet<LanguageSupport> LanguageSupports { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

}

