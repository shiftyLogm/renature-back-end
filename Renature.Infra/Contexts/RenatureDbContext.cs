using Microsoft.EntityFrameworkCore;

namespace Renature.Infra.Contexts;

public class RenatureDbContext(DbContextOptions<RenatureDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(RenatureDbContext).Assembly);
    }
}