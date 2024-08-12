using CSharpFunctionalExtensions;

namespace NetCoreArticles.Core.Models;

/// <summary>
/// Represents an article's image.
/// </summary>
public class ArticleImage
{
    private ArticleImage(string fileName)
    {
        FileName = fileName;
    }
    
    /// <summary>
    /// Gets or sets an article identifier.
    /// </summary>
    public Guid ArticleId { get; set; }
    
    /// <summary>
    /// Gets or sets an article image filename.
    /// </summary>
    public string FileName { get; set; } = string.Empty;

    public static Result<ArticleImage> Create(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return Result.Failure<ArticleImage>($"{nameof(fileName)} cannot be null or empty");
        }

        var newImage = new ArticleImage(fileName);

        return Result.Success(newImage);
    }
}