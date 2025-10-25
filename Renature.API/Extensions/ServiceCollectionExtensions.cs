using Renature.Applications;
using Renature.Infra.Services;

namespace Renature.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void UseApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddInfrastructure(configuration);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddApplications();
    }
}