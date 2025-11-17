using Renature.Infra.Abstractions;
using Renature.Infra.Contexts;
using Renature.Infra.Entities.UsersAchievements.Interfaces;

namespace Renature.Infra.Entities.UsersAchievements;

public class UserAchievementRepository(RenatureDbContext context)
    : Repository<UserAchievement>(context), IUserAchievementRepository
{
    public override IQueryable<UserAchievement> GetAll(Guid? id = null)
    {
        var result = dbSet.AsQueryable();

        return id is null
            ? result
            : result.Where(x => x.UserId == id);
    }
}