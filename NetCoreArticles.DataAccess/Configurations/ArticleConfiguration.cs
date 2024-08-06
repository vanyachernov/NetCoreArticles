using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<ArticleEntity>
{
    public void Configure(EntityTypeBuilder<ArticleEntity> builder)
    {
        builder
            .HasKey(a => a.Id);
        builder
            .HasOne(a => a.Author)
            .WithMany(at => at.Articles)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(a => a.ArticleImage)
            .WithOne(i => i.Article)
            .HasForeignKey<ImageEntity>(i => i.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasMany(a => a.Likes)
            .WithOne(l => l.Article)
            .HasForeignKey(l => l.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(255);
        builder
            .Property(a => a.Content)
            .IsRequired();
        builder
            .Property(a => a.Views)
            .HasDefaultValue(0);
        builder
            .Property(a => a.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);
        builder
            .Property(a => a.UpdatedAt)
            .HasDefaultValue(DateTime.UtcNow);
    }
}