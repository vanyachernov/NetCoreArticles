using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IImagesService
{
    Task<Result<Image>> CreateImage(IFormFile imageFile, CancellationToken cancellationToken = default);
    Task<bool> SaveImage(Guid articleId, Image image, CancellationToken cancellationToken = default);
}