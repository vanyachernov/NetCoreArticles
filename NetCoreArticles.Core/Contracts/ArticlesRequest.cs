using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace NetCoreArticles.Core.Contracts;

public record ArticlesRequest(
    [Required] Guid AuthorId,
    [Required] [MaxLength(255)] string Title,
    [Required] string Content,
    IFormFile TitleImage);