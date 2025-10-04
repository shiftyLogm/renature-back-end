namespace Renature.API.Services;

public static class Builder
{
    public static void UseBuildServices(this WebApplication builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.UseSwagger();
            builder.UseSwaggerUI();
        }
        
        builder.UseHttpsRedirection();
    }
}