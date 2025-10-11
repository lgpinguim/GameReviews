using GameReviews.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameReviews.Infra.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .UseIdentityColumn();

        builder.Property(c => c.Name)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(c => c.Description)
            .HasColumnType("nvarchar(500)")
            .IsRequired();

        builder.Property(d => d.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(d => d.UpdatedAt)
            .HasColumnType("datetime2");

        builder.HasMany(c => c.Games)
            .WithMany(g => g.Categories)
            .UsingEntity(j => j.ToTable("Categories"));
    }
}