using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IImagesRepository
{
    Task<Image> AddAsync(Image image, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid articleId, CancellationToken cancellationToken = default);
}