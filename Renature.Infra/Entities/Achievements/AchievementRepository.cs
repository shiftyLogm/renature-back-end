using Renature.Infra.Abstractions;
using Renature.Infra.Contexts;
using Renature.Infra.Entities.Achievements.Interfaces;

namespace Renature.Infra.Entities.Achievements;

public class AchievementRepository(RenatureDbContext context) : Repository<Achievement>(context), IAchievementRepository;