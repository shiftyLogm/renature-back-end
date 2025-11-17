using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Achievements.Interfaces;
using Renature.Applications.Achievements.Responses;

namespace Renature.API.Controllers;

[Route("api/achievements")]
[ApiController]
[Authorize]
public class AchievementController : ControllerBase
{
    private readonly IAchievementService _achievementService;

    public AchievementController(IAchievementService achievementService)
    {
        _achievementService = achievementService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AchievementResponse>> GetById([FromRoute] Guid id)
    {
        var achievement = await _achievementService.GetById(id, this);
        return achievement;
    }

    [HttpGet]
    public ActionResult<List<AchievementResponse>> GetAll()
    {
        var achievements = _achievementService.GetAll(this);
        return achievements;
    }
}