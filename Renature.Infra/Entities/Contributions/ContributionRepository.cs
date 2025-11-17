using Renature.Infra.Abstractions;
using Renature.Infra.Contexts;
using Renature.Infra.Entities.Contributions.Interfaces;

namespace Renature.Infra.Entities.Contributions;

public class ContributionRepository(RenatureDbContext context)
    : Repository<Contribution>(context), IContributionRepository
{
    public override IQueryable<Contribution> GetAll(Guid? id = null)
    {
        var result = dbSet.AsQueryable();

        return id is null
            ? result
            : result.Where(x => x.UserId == id);
    }
}