using CSharpFunctionalExtensions;

namespace NetCoreArticles.Core.Models;

/// <summary>
/// Represents an article's image.
/// </summary>
public class Image
{
    private Image(string fileName)
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

    public static Result<Image> Create(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return Result.Failure<Image>($"{nameof(fileName)} cannot be null or empty");
        }

        var newImage = new Image(fileName);

        return Result.Success(newImage);
    }
}