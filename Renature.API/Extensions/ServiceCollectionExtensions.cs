namespace Renature.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void UseApiServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}