using CSharpFunctionalExtensions;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IArticlesService
{
    Task<Article> CreateArticleAsync(Article article, CancellationToken cancellationToken = default);
    Task<IEnumerable<Article>> GetAllArticlesAsync(CancellationToken cancellationToken = default);
    Task<Article> GetArticleByIdAsync(Guid articleId, CancellationToken cancellationToken = default);
    Task<IQueryable<Article>> GetArticleByFilterAsync(string title, CancellationToken cancellationToken = default);
    Task<Article> UpdateArticleAsync(Article article, CancellationToken cancellationToken = default);
    Task<Guid> DeleteArticleAsync(Guid articleId, CancellationToken cancellationToken = default);
}