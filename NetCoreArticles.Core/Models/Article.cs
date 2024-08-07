using CSharpFunctionalExtensions;

namespace NetCoreArticles.Core.Models;

/// <summary>
/// Represents an article.
/// </summary>
public class Article
{
    private Article(Guid id, Guid authorId, string title, string content, Image? articleImage)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        Content = content;
        ArticleImage = articleImage;
    }
    
    /// <summary>
    /// Gets an article identifier.
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Gets an article's author identifier.
    /// </summary>
    public Guid AuthorId { get; }

    /// <summary>
    /// Gets an article title.
    /// </summary>
    public string Title { get; } = string.Empty;

    /// <summary>
    /// Gets an article content.
    /// </summary>
    public string Content { get; } = string.Empty;

    /// <summary>
    /// Gets an article views count;
    /// </summary>
    public int Views { get; private set; } = 0;
    
    /// <summary>
    /// Gets an article created date.
    /// </summary>
    public DateTime CreatedAt { get; }
    
    /// <summary>
    /// Gets an article updated date.
    /// </summary>
    public DateTime UpdatedAt { get; }
    
    /// <summary>
    /// Gets an article image.
    /// </summary>
    public Image? ArticleImage { get; }

    public void CountView() => Views++;

    public static Result<Article> Create(Guid id, Guid authorId, string title, string content, Image? articleImage)
    {
        var newArticle = new Article(id, authorId, title, content, articleImage);

        return Result.Success(newArticle);
    }
}