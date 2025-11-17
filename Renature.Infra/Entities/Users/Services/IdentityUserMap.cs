using Microsoft.EntityFrameworkCore;

namespace Renature.Infra.Entities.Users.Services;

public static class IdentityUserMap
{
    public static void ApplyIdentityUserMapping(this ModelBuilder builder) =>
        builder.Entity<User>(entity => entity.ToTable("Users"));
    
}