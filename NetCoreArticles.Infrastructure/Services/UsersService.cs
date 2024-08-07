using CSharpFunctionalExtensions;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Infrastructure.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<User> CreateUserAsync(
        User user, 
        CancellationToken cancellationToken = default)
    {
        return await _usersRepository.CreateAsync(
            user, 
            cancellationToken);
    }

    public async Task<User> UpdateUserAsync(
        User user, 
        CancellationToken cancellationToken = default)
    {
        return await _usersRepository.UpdateAsync(
            user, 
            cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        return await _usersRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Result<User>> GetUserByIdAsync(
        Guid userId, 
        CancellationToken cancellationToken = default)
    {
        return await _usersRepository.GetByIdAsync(
            userId, 
            cancellationToken);
    }
}