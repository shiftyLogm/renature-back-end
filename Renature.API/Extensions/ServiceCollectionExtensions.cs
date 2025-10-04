namespace Renature.API.Services;

public static class Api
{
    public static void UseApiServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}