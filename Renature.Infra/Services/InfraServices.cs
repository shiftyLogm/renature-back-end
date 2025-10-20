using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Renature.Infra.Contexts;
using Renature.Infra.Entities.Stores;
using Renature.Infra.Entities.Stores.Interfaces;

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

        return services;
    }
    
}