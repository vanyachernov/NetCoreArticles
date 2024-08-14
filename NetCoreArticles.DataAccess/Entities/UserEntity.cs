using Microsoft.AspNetCore.Identity;

namespace NetCoreArticles.DataAccess.Entities;

/// <summary>
/// Represents a user entity.
/// </summary>
public class UserEntity : IdentityUser<Guid>
{
    /// <summary>
    /// Gets or sets a user image.
    /// </summary>
    public UserImageEntity? UserImage { get; set; }

    /// <summary>
    /// Gets or sets a user likes collection.
    /// </summary>
    public ICollection<LikeEntity> Likes { get; set; } = [];
    
    /// <summary>
    /// Gets or sets a user articles collection.
    /// </summary>
    public ICollection<ArticleEntity> Articles { get; set; } = [];
}