using CSharpFunctionalExtensions;

namespace NetCoreArticles.Core.Models;

/// <summary>
/// Represents an article.
/// </summary>
public class Article
{
    private Article(Guid id, Guid authorId, User? author, string title, string content, ArticleImage? articleImage)
    {
        Id = id;
        AuthorId = authorId;
        Author = author;
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
    /// Gets an article's author.
    /// </summary>
    public User Author { get; }

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
    public DateTime CreatedAt { get; private set; }
    
    /// <summary>
    /// Gets an article updated date.
    /// </summary>
    public DateTime UpdatedAt { get; private set; }
    
    /// <summary>
    /// Gets an article image.
    /// </summary>
    public ArticleImage? ArticleImage { get; }
    
    public void SetViews(int views) => Views = views;
    
    public void SetCreatedDate(DateTime createdDate) => CreatedAt = createdDate;
    
    public void SetUpdatedDate(DateTime updatedDate) => UpdatedAt = updatedDate;

    public static Result<Article> Create(Guid id, Guid authorId, User? author, string title, string content, ArticleImage? articleImage)
    {
        var newArticle = new Article(id, authorId, author, title, content, articleImage);

        return Result.Success(newArticle);
    }
}