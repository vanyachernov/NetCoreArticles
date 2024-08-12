using System.Linq.Expressions;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Contracts;
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

    public async Task<ICollection<Article>> GetAllAsync(
        GetArticlesRequest request, 
        CancellationToken cancellationToken = default)
    {
        var articleEntities = await _context.Articles
            .Include(a => a.Author)
                .ThenInclude(u => u.UserImage)
            .Include(a => a.ArticleImage)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        var filteredArticles = articleEntities
            .Where(a => string.IsNullOrWhiteSpace(request.Search) || 
                        a.Title.ToLower().Contains(request.Search.ToLower()));

        Expression<Func<ArticleEntity, object>> selectorKey = request.SortItem?.ToLower() switch
        {
            "date" => article => article.CreatedAt,
            "title" => article => article.Title,
            _ => article => article.Id
        };

        filteredArticles = request.SortOrder == "desc"
            ? filteredArticles.OrderByDescending(selectorKey.Compile())
            : filteredArticles.OrderBy(selectorKey.Compile());

        var articles = new List<Article>();

        foreach (var articleEntity in filteredArticles)
        {
            ArticleImage? articleImage = null;
            UserImage? userImage = null;

            if (articleEntity.ArticleImage != null && !string.IsNullOrEmpty(articleEntity.ArticleImage.FileName) && articleEntity.Author.UserImage != null && !string.IsNullOrEmpty(articleEntity.Author.UserImage.FileName))
            {
                var imageResult = ArticleImage.Create(articleEntity.ArticleImage.FileName);
                var userImageResult = UserImage.Create(articleEntity.Author.UserImage.FileName);

                imageResult.Value.ArticleId = articleEntity.Id;
                userImageResult.Value.UserId = articleEntity.AuthorId;

                if (imageResult.IsFailure && userImageResult.IsFailure)
                {
                    _logger.LogError(imageResult.Error);
                    _logger.LogError(userImageResult.Error);
                    break;
                }
                
                articleImage = imageResult.Value;
                userImage = userImageResult.Value;
            }
            else
            {
                _logger.LogError("Article/User image is null or file name is empty for article with ID: " + articleEntity.Id);
            }

            var userResult = User.Create(
                articleEntity.Author.Id, 
                articleEntity.Author.Username,
                articleEntity.Author.Email, 
                articleEntity.Author.PasswordHash,
                userImage
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
            
            articleResult.Value.SetViews(articleEntity.Views);
            articleResult.Value.SetCreatedDate(articleEntity.CreatedAt);
            articleResult.Value.SetUpdatedDate(articleEntity.UpdatedAt);

            if (articleResult.IsFailure)
            {
                _logger.LogError(articleResult.Error);
            }
            
            articles.Add(articleResult.Value);
        }

        return articles;
    }




    public async Task<Result<Article>> GetByIdAsync(
        Guid articleId, 
        CancellationToken cancellationToken = default)
    {
        var articleEntity = await _context.Articles
            .Include(a => a.Author)
                .ThenInclude(u => u.UserImage)
            .Include(a => a.ArticleImage)
            .FirstOrDefaultAsync(a => a.Id == articleId, cancellationToken);

        if (articleEntity == null)
        {
            return Result.Failure<Article>("Article not found!");
        }
        
        Result<UserImage> userImageResult;
        if (articleEntity.Author.UserImage != null && !string.IsNullOrEmpty(articleEntity.Author.UserImage.FileName))
        {
            userImageResult = UserImage.Create(articleEntity.Author.UserImage.FileName);
            if (userImageResult.IsFailure)
            {
                _logger.LogError(userImageResult.Error);
                return Result.Failure<Article>("Invalid user image data.");
            }
        }
        else
        {
            _logger.LogError("User image is null or file name is empty for user with ID: " + articleEntity.Author.Id);
            userImageResult = Result.Failure<UserImage>("User image data is missing.");
        }

        var userImage = userImageResult.Value;
        userImage.UserId = articleEntity.AuthorId;

        await AddViewToArticle(articleEntity, cancellationToken);
        
        var userResult = User.Create(
            articleEntity.Author.Id,
            articleEntity.Author.Username,
            articleEntity.Author.Email,
            articleEntity.Author.PasswordHash,
            userImage
        );

        if (userResult.IsFailure)
        {
            _logger.LogError($"User creation failed. Errors: {userResult.Error}");
            return Result.Failure<Article>("User creation failed.");
        }
        
        var articleImageResult = ArticleImage.Create(articleEntity.ArticleImage?.FileName ?? string.Empty);
        if (articleImageResult.IsFailure)
        {
            _logger.LogError(articleImageResult.Error);
            return Result.Failure<Article>("Invalid article image data.");
        }

        var article = Article.Create(
            articleEntity.Id,
            articleEntity.AuthorId,
            userResult.Value,
            articleEntity.Title,
            articleEntity.Content,
            articleImageResult.Value
        );

        if (article.IsFailure)
        {
            _logger.LogError($"Article creation failed. Errors: {article.Error}");
            return Result.Failure<Article>("Article creation failed.");
        }
        
        article.Value.SetViews(articleEntity.Views);
        article.Value.SetCreatedDate(articleEntity.CreatedAt);
        article.Value.SetUpdatedDate(articleEntity.UpdatedAt);

        return article;
    }

    public Task<IQueryable<Article>> GetByFilterAsync(
        string title, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Article> UpdateAsync(
        Article article, 
        CancellationToken cancellationToken = default)
    {
        await _context.Articles
            .Where(a => a.Id == article.Id)
            .ExecuteUpdateAsync(options => options
                .SetProperty(a => a.Title, article.Title)
                .SetProperty(a => a.Content, article.Content)
                .SetProperty(a => a.UpdatedAt, DateTime.UtcNow), cancellationToken);

        return article;
    }

    public async Task<Guid> DeleteAsync(
        Guid articleId, 
        CancellationToken cancellationToken = default)
    {
        await _context.Articles
            .Where(a => a.Id == articleId)
            .ExecuteDeleteAsync(cancellationToken);

        return articleId;
    }

    private async Task AddViewToArticle(
        ArticleEntity entity, 
        CancellationToken cancellationToken = default)
    {
        entity.Views = entity.Views + 1;

        await _context.SaveChangesAsync(cancellationToken);
    }
}