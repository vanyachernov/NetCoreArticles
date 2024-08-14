using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreArticles.Core.Contracts;
using NetCoreArticles.DataAccess.Entities;

namespace NetCoreArticles.Api.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController(UserManager<UserEntity> userManager) : ControllerBase
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromForm] UsersRequest user)
    {
        if (user is null)
        {
            return BadRequest("User doesn't exists!");
        }

        var newUser = new UserEntity
        {
            Id = Guid.NewGuid(),
            UserName = user.Username,
            Email = user.Email,
            UserImage = new UserImageEntity { FileName = user.UserImage.FileName }
        };
        
        var newUserProcessingResult = await _userManager.CreateAsync(newUser, user.Password);

        if (!newUserProcessingResult.Succeeded)
        {
            var errors = newUserProcessingResult.Errors.Select(e => e.Description);

            return BadRequest(new UserRegistrationResponseDto(false, errors));
        }

        return Created();
    }
}