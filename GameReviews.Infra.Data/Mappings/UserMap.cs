using GameReviews.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameReviews.Infra.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .UseIdentityColumn();

        builder.Property(u => u.Name)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnType("nvarchar(255)")
            .IsRequired();

        builder.Property(u => u.ProfilePictureUrl)
            .HasColumnType("nvarchar(500)");

        builder.Property(u => u.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnType("datetime2");

        builder.Property(u => u.TotalReviews)
            .IsRequired()
            .HasDefaultValue(0);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.HasMany(u => u.Reviews)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}