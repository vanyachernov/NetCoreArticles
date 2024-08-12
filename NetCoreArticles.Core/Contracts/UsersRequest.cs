using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace NetCoreArticles.Core.Contracts;

public record UsersRequest(
    [Required] [MaxLength(60)] string Username,
    [Required] [MaxLength(255)] string Email,
    [Required] string Password);