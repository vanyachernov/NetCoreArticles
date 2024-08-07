using Microsoft.EntityFrameworkCore;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Repositories;

public class ImagesRepository : IImagesRepository
{
    private readonly ApplicationDbContext _context;

    public ImagesRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> AddAsync(Guid articleId, Image image, CancellationToken cancellationToken = default)
    {
        var imageEntity = new ImageEntity
        {
            ArticleId = articleId,
            FileName = image.FileName
        };

        await _context.Images
            .AddAsync(imageEntity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid articleId, CancellationToken cancellationToken = default)
    {
        await _context.Images
            .Where(i => i.ArticleId == articleId)
            .ExecuteDeleteAsync(cancellationToken);

        return true;
    }
}