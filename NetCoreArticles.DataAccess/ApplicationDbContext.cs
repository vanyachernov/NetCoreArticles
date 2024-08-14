using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreArticles.DataAccess.Configurations;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess;

public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<ArticleEntity> Articles { get; set; }
    public DbSet<ImageEntity> Images { get; set; }
    public DbSet<UserImageEntity> UsersImages { get; set; }
    public DbSet<LikeEntity> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
        modelBuilder.ApplyConfiguration(new UsersImageConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new LikeConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}