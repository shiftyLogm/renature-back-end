using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Achievements.Interfaces;
using Renature.Applications.Achievements.Responses;
using Renature.Infra.Entities.Achievements.Interfaces;

namespace Renature.Applications.Achievements.Services;

public class AchievementService(IAchievementRepository achievementRepository, IMapper mapper) : IAchievementService
{
    public async Task<ActionResult<AchievementResponse>> GetById(Guid id, ControllerBase controller)
    {
        var achievement = await achievementRepository.GetById(id);
        
        if (achievement is null) return controller.NotFound("Achievement not found");
        
        return controller.Ok(mapper.Map<AchievementResponse>(achievement));
    }

    public ActionResult<List<AchievementResponse>> GetAll(ControllerBase controller)
    {
        var achievements = achievementRepository.GetAll();
        
        if (!achievements.Any()) return controller.NotFound();
        
        var result = achievements.Select(a => mapper.Map<AchievementResponse>(a)).ToList();
        
        return controller.Ok(result);
    }
}