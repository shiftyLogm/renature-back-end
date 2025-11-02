using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Achievements.Responses;

namespace Renature.Applications.Achievements.Interfaces;

public interface IAchievementService
{
    Task<ActionResult<AchievementResponse>> GetById(Guid id, ControllerBase controller);
    ActionResult<List<AchievementResponse>> GetAll(ControllerBase controller);
}