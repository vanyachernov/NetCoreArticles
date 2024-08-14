using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetCoreArticles.DataAccess.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder
            .HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("223b7835-ebe1-4231-a175-398adb60c9fe"),
                    RoleId = Guid.Parse("8fe9b3b0-ba6a-45f5-ad13-cd9c17bf252f") 
                });
    }
}