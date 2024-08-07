using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IImagesService
{
    Task<Result<Image>> CreateImage(IFormFile imageFile, string path, CancellationToken cancellationToken = default);
}