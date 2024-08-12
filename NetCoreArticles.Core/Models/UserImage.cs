using CSharpFunctionalExtensions;

namespace NetCoreArticles.Core.Models;

/// <summary>
/// Represents an article's image.
/// </summary>
public class UserImage
{
    private UserImage(string fileName)
    {
        FileName = fileName;
    }
    
    /// <summary>
    /// Gets or sets a user identifier.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets or sets a гыук image filename.
    /// </summary>
    public string FileName { get; set; } = string.Empty;

    public static Result<UserImage> Create(string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return Result.Failure<UserImage>($"{nameof(fileName)} cannot be null or empty");
        }

        var newImage = new UserImage(fileName);

        return Result.Success(newImage);
    }
}