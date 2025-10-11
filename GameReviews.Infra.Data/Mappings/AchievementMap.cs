using GameReviews.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameReviews.Infra.Data.Mappings;

public class AchievementMap : IEntityTypeConfiguration<Achievement>
{
    public void Configure(EntityTypeBuilder<Achievement> builder)
    {
        builder.ToTable("Achievements");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .UseIdentityColumn();

        builder.Property(a => a.Name)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder.Property(a => a.Description)
            .HasColumnType("nvarchar(500)")
            .IsRequired();

        builder.Property(a => a.IconUrl)
            .HasColumnType("nvarchar(500)");

        builder.Property(a => a.UnlockPercentage)
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        builder.Property(a => a.IsHidden)
            .IsRequired();

        builder.Property(d => d.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(d => d.UpdatedAt)
            .HasColumnType("datetime2");

        builder.Property(a => a.GameId)
            .IsRequired();

        builder.HasOne(a => a.Game)
            .WithMany(g => g.Achievements)
            .HasForeignKey(a => a.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}