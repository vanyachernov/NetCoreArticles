using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasOne(u => u.UserImage)
            .WithOne(i => i.User)
            .HasForeignKey<UserImageEntity>(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasMany(u => u.Likes)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasMany(u => u.Articles)
            .WithOne(a => a.Author)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}