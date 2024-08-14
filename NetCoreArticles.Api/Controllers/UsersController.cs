using Microsoft.AspNetCore.Mvc;
using NetCoreArticles.Core.Abstractions;
using NetCoreArticles.Core.Contracts;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly IImagesService _imagesService;
    private readonly IPasswordHasherService _passwordHasherService;

    public UsersController(
        IUsersService usersService,
        IImagesService imagesService,
        IPasswordHasherService passwordHasherService)
    {
        _usersService = usersService;
        _imagesService = imagesService;
        _passwordHasherService = passwordHasherService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers(CancellationToken token)
    {
        var users = await _usersService.GetAllUsersAsync(token);
        
        return Ok(users);
    }
    
    [HttpGet]
    [Route("{userId:guid}")]
    public async Task<ActionResult<IEnumerable<User>>> GetUserByIdentifier(
        [FromRoute] Guid userId,
        CancellationToken token)
    {
        var userProcessingResult = await _usersService.GetUserByIdAsync(
            userId, 
            token);

        if (userProcessingResult.IsFailure)
        {
            return BadRequest(userProcessingResult.Error);
        }
        
        return Ok(userProcessingResult.Value);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<User>> CreateUser(
        [FromForm] UsersRequest user,
        CancellationToken token)
    {
        var imageProcessingResult = await _imagesService.CreateUserImage(
            user.UserImage,
            token);

        if (imageProcessingResult.IsFailure)
        {
            return BadRequest(imageProcessingResult.Error);
        }
        
        var userProcessingResult = Core.Models.User.Create(
            Guid.NewGuid(),
            user.Username,
            user.Email,
            imageProcessingResult.Value);

        if (userProcessingResult.IsFailure)
        {
            return BadRequest(userProcessingResult.Error);
        }

        return await _usersService.CreateUserAsync(
            userProcessingResult.Value, 
            token);
    }
}