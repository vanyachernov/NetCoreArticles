namespace NetCoreArticles.DataAccess.Entities;

/// <summary>
/// Represents an article entity.
/// </summary>
public class ArticleEntity
{
    /// <summary>
    /// Gets or sets an article identifier.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Gets or sets an article's author identifier.
    /// </summary>
    public Guid AuthorId { get; set; }
    
    /// <summary>
    /// Gets or sets an article's author.
    /// </summary>
    public UserEntity Author { get; set; }

    /// <summary>
    /// Gets or sets an article title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets an article content.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets an article views count;
    /// </summary>
    public int Views { get; set; } = 0;
    
    /// <summary>
    /// Gets or sets an article created date.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Gets or sets an article updated date.
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Gets or sets an article image.
    /// </summary>
    public ImageEntity? ArticleImage { get; set; }
    
    /// <summary>
    /// Gets or sets an article likes.
    /// </summary>
    public ICollection<LikeEntity>? Likes { get; set; } = [];
}