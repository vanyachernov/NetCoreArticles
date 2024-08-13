using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Configurations;

public class UsersImageConfiguration : IEntityTypeConfiguration<UserImageEntity>
{
    public void Configure(EntityTypeBuilder<UserImageEntity> builder)
    {
        builder.ToTable("UsersImages");
        builder
            .HasKey(u => u.UserId);
        builder
            .Property(u => u.FileName)
            .IsRequired();
    }
}