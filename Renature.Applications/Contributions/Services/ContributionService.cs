using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Renature.Applications.Contributions.Interfaces;
using Renature.Applications.Contributions.Requests;
using Renature.Applications.Contributions.Responses;
using Renature.Infra.Entities.Achievements.Interfaces;
using Renature.Infra.Entities.Contributions;
using Renature.Infra.Entities.Contributions.Interfaces;
using Renature.Infra.Entities.Users;
using Renature.Infra.Entities.UsersAchievements;
using Renature.Infra.Entities.UsersAchievements.Interfaces;

namespace Renature.Applications.Contributions.Services;

public class ContributionService(
    IContributionRepository contributionRepository,
    IAchievementRepository achievementRepository,
    IUserAchievementRepository userAchievementRepository,
    UserManager<User> userManager,
    IMapper mapper) : IContributionService
{
    private readonly int _levelDivisor = 500;
    
    public async Task<ActionResult> CreateContribution(ContributionRequest request, ControllerBase controller)
    {
        var contribution = mapper.Map<Contribution>(request);
        
        await contributionRepository.Add(contribution);

        var user = await userManager.FindByIdAsync(request.UserId);

        if (user is not null)
        {
            user.Points += request.AdquiredPoints;
            user.Level = user.Points / (decimal)_levelDivisor;
            
            var identityResult = await userManager.UpdateAsync(user);
            
            await UpdateAchievementsAsync(user);
            
            if (!identityResult.Succeeded)
                return controller.BadRequest(identityResult.Errors);
        }

        return controller.Ok();
    }

    private async Task UpdateAchievementsAsync(User user)
    {
        var available = await achievementRepository.GetAll()
            .Where(a => user.Level >= a.NecessaryLevel)
            .ToListAsync();
        
        var alreadyGot = await userAchievementRepository.GetAll()
            .Where(ua => ua.UserId == user.Id)
            .Select(ua => ua.AchievementId)
            .ToListAsync();
        
        var newAchievements = available
            .Where(a => !alreadyGot.Contains(a.Id))
            .Select(a => new UserAchievement
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                AchievementId = a.Id
            })
            .ToList();

        foreach (var ach in newAchievements)
            await userAchievementRepository.Add(ach);
    }


    public async Task<ActionResult<ContributionResponse>> GetById(Guid id, ControllerBase controller)
    {
        var contribution = await contributionRepository.GetById(id);
        
        if (contribution is null) return controller.NotFound("Contribution not found");
        
        return controller.Ok(mapper.Map<ContributionResponse>(contribution));
    }

    public ActionResult<List<ContributionResponse>> GetAll(Guid? userId, ControllerBase controller)
    {
        var contributions = contributionRepository.GetAll(userId);
        
        if (!contributions.Any()) return controller.NoContent();
        
        var result = contributions.Select(a => mapper.Map<ContributionResponse>(a)).ToList();
        
        return controller.Ok(result);
    }
}