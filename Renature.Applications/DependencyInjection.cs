using Microsoft.Extensions.DependencyInjection;
using Renature.Applications.Achievements.Interfaces;
using Renature.Applications.Achievements.Services;
using Renature.Applications.Stores.Interfaces;
using Renature.Applications.Stores.Services;

namespace Renature.Applications;

public static class DependencyInjection
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IAchievementService, AchievementService>();

        return services;
    }
}