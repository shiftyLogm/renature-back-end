using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Renature.Infra.Entities.Users;
using Renature.Infra.Entities.Users.Services;

namespace Renature.Infra.Contexts;

public class RenatureDbContext(DbContextOptions<RenatureDbContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyIdentityUserMapping();
        builder.ApplyConfigurationsFromAssembly(typeof(RenatureDbContext).Assembly);
    }
}