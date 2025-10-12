using GameReviews.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameReviews.Infra.Data.Mappings;

public class GameMap : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .UseIdentityColumn();

        builder.Property(g => g.Title)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder.Property(g => g.Description)
            .HasColumnType("nvarchar(max)")
            .IsRequired();

        builder.Property(g => g.ReleaseDate)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(g => g.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(g => g.CoverImageUrl)
            .HasColumnType("nvarchar(500)");

        builder.Property(g => g.TrailerUrl)
            .HasColumnType("nvarchar(500)");

        builder.Property(g => g.MetacriticScore);

        builder.Property(g => g.IsEarlyAccess)
            .IsRequired();

        builder.Property(g => g.AgeRating)
            .HasColumnType("nvarchar(50)");

        builder.Property(g => g.LastUpdated)
            .HasColumnType("datetime2");

        builder.Property(g => g.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(g => g.UpdatedAt)
            .HasColumnType("datetime2");


        builder.HasMany(g => g.Developers)
            .WithMany(d => d.Games)
            .UsingEntity(j => j.ToTable("GameDevelopers"));

        builder.HasMany(g => g.Publishers)
            .WithMany(p => p.Games)
            .UsingEntity(j => j.ToTable("GamePublishers"));

        builder.HasMany(g => g.Categories)
            .WithMany(c => c.Games)
            .UsingEntity(j => j.ToTable("GameCategories"));

        builder.HasMany(g => g.Platforms)
            .WithMany(p => p.Games)
            .UsingEntity(j => j.ToTable("GamePlatforms"));

        builder.HasMany(g => g.LanguageSupport)
            .WithOne(ls => ls.Game)
            .HasForeignKey(ls => ls.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.Achievements)
            .WithOne(a => a.Game)
            .HasForeignKey(a => a.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.Reviews)
            .WithOne(r => r.Game)
            .HasForeignKey(r => r.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}