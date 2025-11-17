using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Renature.Infra.Contexts;
using Renature.Infra.Entities.Achievements;
using Renature.Infra.Entities.Achievements.Interfaces;
using Renature.Infra.Entities.Contributions;
using Renature.Infra.Entities.Contributions.Interfaces;
using Renature.Infra.Entities.Stores;
using Renature.Infra.Entities.Stores.Interfaces;
using Renature.Infra.Entities.UsersAchievements;
using Renature.Infra.Entities.UsersAchievements.Interfaces;
using Renature.Infra.JWT;
using Renature.Infra.JWT.Interfaces;

namespace Renature.Infra.Services;

public static class InfraServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connnectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Database connection string is missing or empty.");
        
        services.ConnectDatabase(connnectionString);
        services.AddDependencies();
        
        return services;
    }

    private static IServiceCollection ConnectDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<RenatureDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }

    private static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IAchievementRepository, AchievementRepository>();
        services.AddScoped<IContributionRepository, ContributionRepository>();
        services.AddScoped<IUserAchievementRepository, UserAchievementRepository>();
        
        services.AddScoped<IRenatureTokenDescriptor, RenatureTokenDescriptor>();
        
        return services;
    }
    
}