using Microsoft.AspNetCore.Mvc;
using NetCoreArticles.Core.Models;

namespace NetCoreArticles.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<User>> CreateUser(
        User user,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }
}