using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<ImageEntity>
{
    public void Configure(EntityTypeBuilder<ImageEntity> builder)
    {
        builder.ToTable("ArticleImages");
        builder
            .HasKey(i => i.ArticleId);
        builder
            .Property(i => i.FileName)
            .IsRequired();
    }
}