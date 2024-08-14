using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreArticles.Core.Contracts;
using NetCoreArticles.DataAccess.Entities;
using NetCoreArticles.Infrastructure.Features;

namespace NetCoreArticles.Api.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly JwtHandler _jwtHandler;

    public AccountController(
        UserManager<UserEntity> userManager,
        JwtHandler jwtHandler)
    {
        _userManager = userManager;
        _jwtHandler = jwtHandler;
    }
    
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

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationRequestDto userAuth)
    {
        var user = await _userManager.FindByEmailAsync(userAuth.Email!);

        if (user is null || !await _userManager.CheckPasswordAsync(user, userAuth.Password!))
        {
            return Unauthorized(new AuthResponseDto(false, "Invalid Authentication", null));
        }

        var token = _jwtHandler.CreateToken(user);

        return Ok(new AuthResponseDto(true, null, token));
    }
}