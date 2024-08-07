namespace NetCoreArticles.Core.Abstractions;

public interface IPasswordHasherService
{
    string Generate(string password);
    bool Verify(string password, string hashedPassword);
}