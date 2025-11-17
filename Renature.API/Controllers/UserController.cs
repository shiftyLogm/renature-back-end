using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Users.Interfaces;
using Renature.Applications.Users.Requests;
using Renature.Applications.Users.Responses;
using Renature.Infra.Entities.UsersAchievements;

namespace Renature.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegister request)
    {
        var result = await _userService.Register(request, this);
        return result;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLogin request)
    {
        var result = await _userService.Login(request, this);
        return result;
    }

    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse>> GetUserById(Guid id)
    {
        var result = await _userService.GetUserById(id, this);
        return result;
    }

    [Authorize]
    [HttpGet("achievements/{id:guid}")]
    public ActionResult<List<UserAchievement>> GetAchievementsByUserId(Guid id)
    {
        var result = _userService.GetAchievementsByUserId(id, this);
        return result;
    }
}