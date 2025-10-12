using GameReviews.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameReviews.Infra.Data.Mappings;

public class DeveloperMap : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.ToTable("Developers");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .UseIdentityColumn();

        builder.Property(d => d.Name)
            .HasColumnType("nvarchar(200)")
            .IsRequired();

        builder.Property(d => d.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(d => d.UpdatedAt)
            .HasColumnType("datetime2");

        builder.HasMany(d => d.Games)
            .WithMany(g => g.Developers)
            .UsingEntity(j => j.ToTable("GameDevelopers"));
    }
}