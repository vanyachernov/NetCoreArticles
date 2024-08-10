namespace NetCoreArticles.Core.Contracts;

public record ArticleResponse(
    Guid Id,
    UsersResponse Author,
    string Title,
    string Content,
    int Views,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    ImagesResponse Image);