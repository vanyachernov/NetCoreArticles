namespace NetCoreArticles.DataAccess.Entities;

/// <summary>
/// Represents a user's like article entity.
/// </summary>
public class LikeEntity
{
    /// <summary>
    /// Gets or sets an article like identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets an article identifier.
    /// </summary>
    public Guid ArticleId { get; set; }
    
    /// <summary>
    /// Gets or sets an article.
    /// </summary>
    public ArticleEntity Article { get; set; }
    
    /// <summary>
    /// Gets or sets an article user identifier.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets or sets an article user.
    /// </summary>
    public UserEntity User { get; set; }
    
    /// <summary>
    /// Gets or sets a like created date.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}