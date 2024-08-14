using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Models;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.DataAccess.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _context;

    public UsersRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        var userEntity = new UserEntity
        {
            Id = user.Id,
            UserName = user.Username,
            Email = user.Email,
        };

        await _context.Users
            .AddAsync(userEntity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users
            .Where(u => u.Id == user.Id)
            .ExecuteUpdateAsync(options => options
                .SetProperty(u => u.Email, user.Email), cancellationToken);

        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var userEntities = await _context.Users
            .Include(u => u.UserImage)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    
        var users = userEntities.Select(u =>
            {
                var userImageResult = UserImage.Create(u.UserImage.FileName);
                
                if (userImageResult.IsSuccess)
                {
                    return User.Create(
                        u.Id,
                        u.UserName,
                        u.Email,
                        userImageResult.Value
                    ).Value;
                }
                else
                {
                    return null;
                }
            })
            .Where(r => r != null)
            .ToList();

        return users;
    }


    public async Task<Result<User>> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var userEntity = await _context.Users
            .Include(u => u.UserImage)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

        if (userEntity == null)
        {
            return Result.Failure<User>("User not found!");
        }

        var userImageResult = UserImage.Create(userEntity.UserImage?.FileName);

        if (userImageResult.IsFailure)
        {
            return Result.Failure<User>("Invalid user image data.");
        }

        var user = User.Create(
            userEntity.Id,
            userEntity.UserName,
            userEntity.Email,
            userImageResult.Value
        );

        return user;
    }

}