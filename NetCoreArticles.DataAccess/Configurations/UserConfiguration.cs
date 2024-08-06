using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasKey(u => u.Id);
        builder
            .Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(60);
        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);
        builder
            .Property(u => u.PasswordHash)
            .IsRequired();
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