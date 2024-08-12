namespace NetCoreArticles.DataAccess.Entities;

/// <summary>
/// Represents a user entity.
/// </summary>
public class UserEntity
{
    /// <summary>
    /// Gets or sets a user identifier.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets a user name.
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Gets or sets a user email.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Gets or sets a user hash password.
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    /// Gets or sets a user likes collection.
    /// </summary>
    public ICollection<LikeEntity> Likes { get; set; } = [];
    
    /// <summary>
    /// Gets or sets a user articles collection.
    /// </summary>
    public ICollection<ArticleEntity> Articles { get; set; } = [];
}