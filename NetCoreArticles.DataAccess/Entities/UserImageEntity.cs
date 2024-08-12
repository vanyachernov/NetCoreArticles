namespace NetCoreArticles.DataAccess.Entities;

/// <summary>
/// Represents a user's image entity.
/// </summary>
public class UserImageEntity
{
    /// <summary>
    /// Gets or sets a user identifier.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets or sets a user.
    /// </summary>
    public UserEntity? User { get; set; }
    
    /// <summary>
    /// Gets or sets a user image filename.
    /// </summary>
    public string FileName { get; set; } = string.Empty;
}