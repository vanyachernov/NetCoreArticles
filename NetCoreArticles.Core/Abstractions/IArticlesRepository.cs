using CSharpFunctionalExtensions;
using NetCoreArticles.Core.Contracts;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IArticlesRepository
{
    Task<Article> CreateAsync(Article article, CancellationToken cancellationToken = default);
    Task<ICollection<Article>> GetAllAsync(GetArticlesRequest request, CancellationToken cancellationToken = default);
    Task<Result<Article>> GetByIdAsync(Guid articleId, CancellationToken cancellationToken = default);
    Task<IQueryable<Article>> GetByFilterAsync(string title, CancellationToken cancellationToken = default);
    Task<Article> UpdateAsync(Article article, CancellationToken cancellationToken = default);
    Task<Guid> DeleteAsync(Guid articleId, CancellationToken cancellationToken = default);
}