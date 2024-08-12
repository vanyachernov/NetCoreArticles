using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Configurations;

public class LikeConfiguration : IEntityTypeConfiguration<LikeEntity>
{
    public void Configure(EntityTypeBuilder<LikeEntity> builder)
    {
        builder
            .HasKey(l => l.Id);
        builder
            .HasOne(l => l.Article)
            .WithMany(a => a.Likes)
            .HasForeignKey(l => l.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(l => l.User)
            .WithMany(u => u.Likes)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .Property(l => l.CreatedAt)
            .HasDefaultValue(DateTime.UtcNow);
    }
}