using CSharpFunctionalExtensions;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Core.Abstractions;

public interface IUsersRepository
{
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
    Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<User>> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
}