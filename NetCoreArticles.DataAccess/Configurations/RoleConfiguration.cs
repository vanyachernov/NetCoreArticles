using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder
            .HasData(
                new RoleEntity
                {
                    Id = Guid.Parse("8fe9b3b0-ba6a-45f5-ad13-cd9c17bf252f"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Description = "The admin role for the user"
                },
                new RoleEntity
                {
                    Id = Guid.Parse("27488e9b-f2a2-4219-953c-221422425978"),
                    Name = "Creator",
                    NormalizedName = "CREATOR",
                    Description = "The creator role for the user"
                });
    }
}