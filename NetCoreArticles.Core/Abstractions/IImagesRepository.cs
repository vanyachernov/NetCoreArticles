using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IImagesRepository
{
    Task<bool> AddAsync(Guid articleId, ArticleImage articleImage, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid articleId, CancellationToken cancellationToken = default);
}