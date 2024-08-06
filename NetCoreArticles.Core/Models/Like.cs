using CSharpFunctionalExtensions;

namespace NetCoreArticles.Core.Models;

/// <summary>
/// Represents a user's like article.
/// </summary>
public class Like
{
    private Like(Guid id, Guid articleId, Guid userId, DateTime createdAt)
    {
        Id = id;
        ArticleId = articleId;
        UserId = userId;
        CreatedAt = createdAt;
    }
    
    /// <summary>
    /// Gets an article like identifier.
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Gets an article identifier.
    /// </summary>
    public Guid ArticleId { get; }
    
    /// <summary>
    /// Gets an article user identifier.
    /// </summary>
    public Guid UserId { get; }
    
    /// <summary>
    /// Gets a like created date.
    /// </summary>
    public DateTime CreatedAt { get; }

    public static Result<Like> Create(Guid id, Guid articleId, Guid userId, DateTime createdAt)
    {
        var newArticleLike = new Like(id, articleId, userId, createdAt);

        return Result.Success(newArticleLike);
    }
}