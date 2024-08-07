using Microsoft.EntityFrameworkCore;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Repositories;

public class LikesRepository: ILikesRepository
{
    private readonly ApplicationDbContext _context;

    public LikesRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Like> AddAsync(Like like, CancellationToken cancellationToken = default)
    {
        var likeEntity = new LikeEntity
        {
            Id = like.Id,
            ArticleId = like.ArticleId,
            UserId = like.UserId,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Likes
            .AddAsync(likeEntity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return like;
    }

    public async Task<bool> DeleteAsync(Guid articleId, Guid userId, CancellationToken cancellationToken = default)
    {
        await _context.Likes
            .Where(l => l.ArticleId == articleId && l.UserId == userId)
            .ExecuteDeleteAsync(cancellationToken);
        
        return true;
    }
}