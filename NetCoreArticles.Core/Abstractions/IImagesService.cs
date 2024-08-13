using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IImagesService
{
    Task<Result<ArticleImage>> CreateArticleImage(IFormFile imageFile, CancellationToken cancellationToken = default);
    Task<Result<UserImage>> CreateUserImage(IFormFile imageFile, CancellationToken cancellationToken = default);
    Task<bool> SaveImage(Guid articleId, ArticleImage articleImage, CancellationToken cancellationToken = default);
}