namespace NetCoreArticles.Core.Contracts;

public record UsersResponse(
    string Username,
    string Email,
    ImagesResponse Image);

public record UserRegistrationResponseDto(
    bool IsSuccessfulRegistration,
    IEnumerable<string>? Errors); 