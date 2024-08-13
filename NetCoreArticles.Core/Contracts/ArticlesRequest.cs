using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace NetCoreArticles.Core.Contracts;

public record CreateArticlesRequest(
    [Required] Guid AuthorId,
    [Required] [MaxLength(255)] string Title,
    [Required] string Content,
    IFormFile TitleImage);

public record GetArticlesRequest(
    string? Search,
    string? SortItem,
    string? SortOrder);
    