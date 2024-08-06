namespace NetCoreArticles.Core.Models;

/// <summary>
/// Represents a user.
/// </summary>
public class User
{
    private User(Guid id, string username, string email, string passwordHash)
    {
        Id = id;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
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

    public static User Create(Guid id, string username, string email, string passwordHash)
    {
        return new User(id, username, email, passwordHash);
    }
}