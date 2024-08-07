using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface ILikesService
{
    Task<Like> AddLikeToArticleAsync(Like like, CancellationToken cancellationToken = default);
    Task<bool> DeleteLikeAsync(Guid articleId, Guid userId, CancellationToken cancellationToken = default);
}