using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface ILikesRepository
{
    Task<Like> AddAsync(Like like, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid articleId, Guid userId, CancellationToken cancellationToken = default);
}