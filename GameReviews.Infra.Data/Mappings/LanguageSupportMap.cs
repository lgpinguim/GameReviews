using GameReviews.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameReviews.Infra.Data.Mappings;

public class LanguageSupportMap : IEntityTypeConfiguration<LanguageSupport>
{
    public void Configure(EntityTypeBuilder<LanguageSupport> builder)
    {
        builder.ToTable("LanguageSupport");

        builder.HasKey(ls => ls.Id);

        builder.Property(ls => ls.Id)
            .UseIdentityColumn();

        builder.Property(ls => ls.Language)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(ls => ls.Interface)
            .IsRequired();

        builder.Property(ls => ls.Audio)
            .IsRequired();

        builder.Property(ls => ls.Subtitles)
            .IsRequired();

        builder.Property(ls => ls.CreatedAt)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(ls => ls.UpdatedAt)
            .HasColumnType("datetime2");

        builder.Property(ls => ls.GameId)
            .HasColumnName("GameId")
            .IsRequired();

        builder.HasOne(ls => ls.Game)
            .WithMany(g => g.LanguageSupport)
            .HasForeignKey(ls => ls.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}