using Microsoft.AspNetCore.Identity;

namespace NetCoreArticles.DataAccess.Entities;

/// <summary>
/// Represents a role entity.
/// </summary>
public class RoleEntity : IdentityRole<Guid>
{
    /// <summary>
    /// Gets or sets a role description.
    /// </summary>
    public string? Description { get; set; }
}