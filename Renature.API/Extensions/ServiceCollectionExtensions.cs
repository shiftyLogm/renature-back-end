using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
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
        services.UseJwtConfiguration(configuration);
        #endregion

        #region Identity Configuration
        services
            .AddIdentityCore<User>()
            .AddEntityFrameworkStores<RenatureDbContext>()
            .AddDefaultTokenProviders();
        #endregion
        
        #region Identity User Configuration
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 0;
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ áàãâéêíóôõúçÁÀÃÂÉÊÍÓÔÕÚÇ ";
        });
        #endregion
    }
    
    private static IServiceCollection UseJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:SecretKey"]);
        
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
            });
        
        services.AddAuthorization();

        return services;
    }
}