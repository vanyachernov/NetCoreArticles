namespace NetCoreArticles.DataAccess.Entities;

/// <summary>
/// Represents an article's image entity.
/// </summary>
public class ImageEntity
{
    /// <summary>
    /// Gets or sets an article identifier.
    /// </summary>
    public Guid ArticleId { get; set; }
    
    /// <summary>
    /// Gets or sets an article.
    /// </summary>
    public ArticleEntity? Article { get; set; }
    
    /// <summary>
    /// Gets or sets an article image filename.
    /// </summary>
    public string FileName { get; set; } = string.Empty;
}