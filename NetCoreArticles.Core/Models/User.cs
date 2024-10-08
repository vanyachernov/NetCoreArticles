using CSharpFunctionalExtensions;

namespace NetCoreArticles.Core.Models;

/// <summary>
/// Represents a user.
/// </summary>
public class User
{
    private User(Guid id, string username, string email, string passwordHash, UserImage? userImage)
    {
        Id = id;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        UserImage = userImage;
    }
    
    /// <summary>
    /// Gets a user identifier.
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Gets a user name.
    /// </summary>
    public string Username { get; }
    
    /// <summary>
    /// Gets a user email.
    /// </summary>
    public string Email { get; }
    
    /// <summary>
    /// Gets a user hash password.
    /// </summary>
    public string PasswordHash { get; }
    
    /// <summary>
    /// Gets a user image.
    /// </summary>
    public UserImage? UserImage { get; }

    public static Result<User> Create(Guid id, string username, string email, string passwordHash, UserImage? userImage)
    {
        var newUser = new User(id, username, email, passwordHash, userImage);

        return Result.Success(newUser);
    }
}