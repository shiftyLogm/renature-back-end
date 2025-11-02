using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Renature.Infra.Entities.Users.Services;

public static class IdentityUserMap
{
    public static void ApplyIdentityUserMapping(this ModelBuilder builder)
    {
        builder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.Property(u => u.Id)
                .HasDefaultValueSql("gen_random_uuid()");
        });
        
        builder.Entity<IdentityUserToken<Guid>>(entity =>
        {
            entity.ToTable("UserTokens");
            entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        });
    }
}