using GameReviews.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameReviews.Infra.Data.Mappings;

public class ReviewMap : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .UseIdentityColumn();

        builder.Property(r => r.Recommended)
            .IsRequired();

        builder.Property(r => r.UserName)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(r => r.ReviewText)
            .HasColumnType("nvarchar(max)")
            .IsRequired();

        builder.Property(r => r.HoursPlayed)
            .HasColumnType("real")
            .IsRequired();

        builder.Property(r => r.DatePosted)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(r => r.DateUpdated)
            .HasColumnType("datetime2");

        builder.Property(r => r.HelpfulCount)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(r => r.UnhelpfulCount)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(r => r.ReceivedForFree)
            .IsRequired();

        builder.Property(r => r.EarlyAccessReview)
            .IsRequired();

        builder.Property(r => r.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(r => r.UpdatedAt)
            .HasColumnType("datetime2");

        builder.Property(r => r.UserId)
            .IsRequired();

        builder.Property(r => r.GameId)
            .IsRequired();

        builder.HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Game)
            .WithMany(g => g.Reviews)
            .HasForeignKey(r => r.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}