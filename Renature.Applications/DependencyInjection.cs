using Microsoft.Extensions.DependencyInjection;
using Renature.Applications.Achievements.Interfaces;
using Renature.Applications.Achievements.Services;
using Renature.Applications.Contributions.Interfaces;
using Renature.Applications.Contributions.Services;
using Renature.Applications.Stores.Interfaces;
using Renature.Applications.Stores.Services;
using Renature.Applications.Users.Interfaces;
using Renature.Applications.Users.Services;

namespace Renature.Applications;

public static class DependencyInjection
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IAchievementService, AchievementService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IContributionService, ContributionService>();
        
        return services;
    }
}