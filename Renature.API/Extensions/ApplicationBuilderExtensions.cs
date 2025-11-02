using Renature.Infra.Entities.Users;

namespace Renature.API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseApiMiddlewares(this WebApplication builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.UseSwagger();
            builder.UseSwaggerUI();
        }
        
        builder.UseHttpsRedirection();
        builder.UseRouting();
        builder.MapControllers();
        // builder.MapIdentityApi<User>().WithTags("Identity User");
    }
}