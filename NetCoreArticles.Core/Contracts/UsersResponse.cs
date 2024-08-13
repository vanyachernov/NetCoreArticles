namespace NetCoreArticles.Core.Contracts;

public record UsersResponse(
    string Username,
    string Email,
    ImagesResponse Image);