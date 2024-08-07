using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Repositories;

public class ArticlesRepository : IArticlesRepository
{
    private readonly ApplicationDbContext _context;

    public ArticlesRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Article> CreateAsync(Article article, CancellationToken cancellationToken = default)
    {
        var articleEntity = new ArticleEntity
        {
            Id = article.Id,
            AuthorId = article.AuthorId,
            Title = article.Title,
            Content = article.Content,
            Views = article.Views,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _context.Articles
            .AddAsync(articleEntity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return article; 
    }

    public async Task<IEnumerable<Article>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var articleEntities = await _context.Articles
            .Include(a => a.Author)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var articles = articleEntities.Select(a => Article.Create(
                a.Id, 
                a.AuthorId, 
                a.Title, 
                a.Content, 
                a.Views, 
                a.CreatedAt, 
                a.UpdatedAt
            ))
            .Where(r => r.IsSuccess)
            .Select(r => r.Value)
            .ToList();

        return articles;
    }

    public async Task<Result<Article>> GetByIdAsync(Guid articleId, CancellationToken cancellationToken = default)
    {
        var articleEntity = await _context.Articles
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == articleId, cancellationToken);

        if (articleEntity == null)
        {
            return Result.Failure<Article>("Article not found!");
        }
        
        var article = Article.Create(
            articleEntity.Id, 
            articleEntity.AuthorId, 
            articleEntity.Title,
            articleEntity.Content, 
            articleEntity.Views, 
            articleEntity.CreatedAt, 
            articleEntity.UpdatedAt);

        return article;
    }

    public Task<IQueryable<Article>> GetByFilterAsync(string title, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Article> UpdateAsync(Article article, CancellationToken cancellationToken = default)
    {
        await _context.Articles
            .Where(a => a.Id == article.Id)
            .ExecuteUpdateAsync(options => options
                .SetProperty(a => a.Title, article.Title)
                .SetProperty(a => a.Content, article.Content)
                .SetProperty(a => a.UpdatedAt, DateTime.UtcNow), cancellationToken);

        return article;
    }

    public async Task<Guid> DeleteAsync(Guid articleId, CancellationToken cancellationToken = default)
    {
        await _context.Articles
            .Where(a => a.Id == articleId)
            .ExecuteDeleteAsync(cancellationToken);

        return articleId;
    }
}