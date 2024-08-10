using System.Net.Mime;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Repositories;

public class ArticlesRepository : IArticlesRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ArticlesRepository> _logger;

    public ArticlesRepository(
        ApplicationDbContext context,
        ILogger<ArticlesRepository> logger)
    {
        _context = context;
        _logger = logger;
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
            .Include(u => u.Author)
            .Include(a => a.ArticleImage)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var articles = new List<Article>();

        foreach (var articleEntity in articleEntities)
        {
            Image? articleImage = null;

            if (articleEntity.ArticleImage != null && !string.IsNullOrEmpty(articleEntity.ArticleImage.FileName))
            {
                var imageResult = Image.Create(articleEntity.ArticleImage.FileName);

                imageResult.Value.ArticleId = articleEntity.Id;

                if (imageResult.IsFailure)
                {
                    _logger.LogError(imageResult.Error);
                    break;
                }
                
                articleImage = imageResult.Value;
            }
            else
            {
                _logger.LogError("Article image is null or file name is empty for article with ID: " + articleEntity.Id);
            }

            var userResult = User.Create(
                articleEntity.Author.Id, 
                articleEntity.Author.Username,
                articleEntity.Author.Email, 
                articleEntity.Author.PasswordHash
            );

            if (userResult.IsFailure)
            {
                _logger.LogError($"User has not been initialized. Errors: {userResult.Error}");
            }

            var articleResult = Article.Create(
                articleEntity.Id,
                articleEntity.AuthorId,
                userResult.Value,
                articleEntity.Title,
                articleEntity.Content,
                articleImage
            );
            
            

            if (articleResult.IsFailure)
            {
                _logger.LogError(articleResult.Error);
            }
            
            articles.Add(articleResult.Value);
        }

        return articles;
    }



    public async Task<Result<Article>> GetByIdAsync(Guid articleId, CancellationToken cancellationToken = default)
    {
        var articleEntity = await _context.Articles
            .Include(a => a.Author)
            .Include(a => a.ArticleImage)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == articleId, cancellationToken);

        if (articleEntity == null)
        {
            return Result.Failure<Article>("Article not found!");
        }
        
        var userResult = User.Create(
            articleEntity.Author.Id, 
            articleEntity.Author.Username,
            articleEntity.Author.Email, 
            articleEntity.Author.PasswordHash
        );

        if (userResult.IsFailure)
        {
            _logger.LogError($"User has not been initialized. Errors: {userResult.Error}");
        }
        
        var article = Article.Create(
            articleEntity.Id, 
            articleEntity.AuthorId,
            userResult.Value,
            articleEntity.Title,
            articleEntity.Content,
            Image.Create(articleEntity.ArticleImage.FileName).Value);

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