using Microsoft.AspNetCore.Identity;
using Renature.Applications;
using Renature.Infra.Contexts;
using Renature.Infra.Entities.Users;
using Renature.Infra.Services;

namespace Renature.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void UseApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Base Configuration
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        #endregion

        #region Infrastructure & Application
        services.AddInfrastructure(configuration);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddApplications();
        #endregion

        #region Authentication & Authorization
        services.AddAuthentication();
        services.AddAuthorization();
        #endregion

        #region Identity Configuration
        services
            .AddIdentityCore<User>()
            .AddEntityFrameworkStores<RenatureDbContext>()
            .AddDefaultTokenProviders();
        #endregion
    }
}