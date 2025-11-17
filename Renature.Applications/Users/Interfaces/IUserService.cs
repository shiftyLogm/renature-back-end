using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Users.Requests;
using Renature.Applications.Users.Responses;
using Renature.Infra.Entities.UsersAchievements;

namespace Renature.Applications.Users.Interfaces;

public interface IUserService
{
    Task<IActionResult> Register(UserRegister request, ControllerBase controller);
    Task<IActionResult> Login(UserLogin request, ControllerBase controller);
    Task<ActionResult<UserResponse>> GetUserById(Guid id, ControllerBase controller);
    ActionResult<List<UserAchievement>> GetAchievementsByUserId(Guid userId, ControllerBase controller);
}