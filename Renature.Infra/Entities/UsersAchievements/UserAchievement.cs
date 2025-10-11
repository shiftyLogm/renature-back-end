using Renature.Infra.Entities.Achievements;
using Renature.Infra.Entities.Users;

namespace Renature.Infra.Entities.UsersAchievements;

public class UserAchievement
{
    public Guid UserId { get; set; }
    public Guid AchievementId { get; set; }
    
    #region Foreign Keys
    
    public User User { get; set; }
    public Achievement Achievement { get; set; }
    
    #endregion
}