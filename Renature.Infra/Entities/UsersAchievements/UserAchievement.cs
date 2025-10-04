namespace Renature.Infra.Entities.UserAchievements;

public class UserAchievements
{
    public Guid UserId { get; set; }
    public Guid AchievementId { get; set; }
    
    #region Foreign Keys
    
    public User.User User { get; set; }
    public Achievement.Achievement Achievement { get; set; }
    
    #endregion
}