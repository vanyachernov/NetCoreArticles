using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Contracts;
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

    public async Task<IEnumerable<ArticleResponse>> GetAllArticlesAsync(CancellationToken cancellationToken = default)
    {
        var articlesData = await _articlesRepository.GetAllAsync(cancellationToken);
        
        var articlesDto = articlesData.Select(a => new ArticleResponse(
            a.Id,
            new UsersResponse(a.Author.Username, a.Author.Email, new ImagesResponse(a.Author?.UserImage?.FileName!)),
            a.Title,
            a.Content,
            a.Views,
            a.CreatedAt,
            a.UpdatedAt,
            new ImagesResponse(a.ArticleImage?.FileName ?? string.Empty)
        ));
        
        return articlesDto;
    }

    public async Task<ArticleResponse> GetArticleByIdAsync(
        Guid articleId, 
        CancellationToken cancellationToken = default)
    {
        var article = await _articlesRepository.GetByIdAsync(
            articleId, 
            cancellationToken);

        var articleEntity = article.Value;

        var articleDto = new ArticleResponse(
            articleEntity.Id,
            new UsersResponse(articleEntity.Author.Username, articleEntity.Author.Email, new ImagesResponse(articleEntity.Author.UserImage.FileName)),
            articleEntity.Title,
            articleEntity.Content,
            articleEntity.Views,
            articleEntity.CreatedAt,
            articleEntity.UpdatedAt,
            new ImagesResponse(articleEntity.ArticleImage?.FileName ?? string.Empty));
        
        return articleDto;
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