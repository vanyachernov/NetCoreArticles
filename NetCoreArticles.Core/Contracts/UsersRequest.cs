using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace NetCoreArticles.Core.Contracts;

public record UsersRequest(
    [Required] [MaxLength(60)] string Username,
    [Required] [MaxLength(255)] string Email,
    [Required] string Password,
    IFormFile UserImage);

public record UserAuthenticationRequestDto(
    [Required(ErrorMessage = "Email is required")] string Email,
    [Required(ErrorMessage = "Password is required")] string Password);
    
public record AuthResponseDto(
    bool IsAuthSuccessful,
    string? ErrorMessage,
    string? Token);
    