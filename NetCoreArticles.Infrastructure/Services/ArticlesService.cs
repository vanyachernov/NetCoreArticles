using CSharpFunctionalExtensions;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Infrastructure.Services;

public class ArticlesService : IArticlesService
{
    private readonly IArticlesRepository _articlesRepository;

    public ArticlesService(IArticlesRepository articlesRepository)
    {
        _articlesRepository = articlesRepository;
    }
    
    public async Task<Article> CreateArticleAsync(
        Article article, 
        CancellationToken cancellationToken = default)
    {
        return await _articlesRepository.CreateAsync(
            article, 
            cancellationToken);
    }

    public async Task<IEnumerable<Article>> GetAllArticlesAsync(CancellationToken cancellationToken = default)
    {
        return await _articlesRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Article> GetArticleByIdAsync(
        Guid articleId, 
        CancellationToken cancellationToken = default)
    {
        var article = await _articlesRepository.GetByIdAsync(
            articleId, 
            cancellationToken);
        
        return article.Value;
    }

    public Task<IQueryable<Article>> GetArticleByFilterAsync(
        string title, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
 
    public async Task<Article> UpdateArticleAsync(
        Article article, 
        CancellationToken cancellationToken = default)
    {
        return await _articlesRepository.UpdateAsync(article, cancellationToken);
    }

    public async Task<Guid> DeleteArticleAsync(
        Guid articleId, 
        CancellationToken cancellationToken = default)
    {
        return await _articlesRepository.DeleteAsync(
            articleId, 
            cancellationToken);
    }
}