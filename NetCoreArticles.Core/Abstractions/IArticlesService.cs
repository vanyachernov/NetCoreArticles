using CSharpFunctionalExtensions;
using NetCoreArticles.Core.Contracts;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IArticlesService
{
    Task<Article> CreateArticleAsync(Article article, CancellationToken cancellationToken = default);
    Task<IEnumerable<ArticleResponse>> GetAllArticlesAsync(CancellationToken cancellationToken = default);
    Task<ArticleResponse> GetArticleByIdAsync(Guid articleId, CancellationToken cancellationToken = default);
    Task<IQueryable<Article>> GetArticleByFilterAsync(string title, CancellationToken cancellationToken = default);
    Task<Article> UpdateArticleAsync(Article article, CancellationToken cancellationToken = default);
    Task<Guid> DeleteArticleAsync(Guid articleId, CancellationToken cancellationToken = default);
}