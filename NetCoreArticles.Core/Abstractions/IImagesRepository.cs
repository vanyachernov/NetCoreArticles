using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IImagesRepository
{
    Task<bool> AddAsync(Guid articleId, Image image, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid articleId, CancellationToken cancellationToken = default);
}