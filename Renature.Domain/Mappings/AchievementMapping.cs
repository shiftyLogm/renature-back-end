using AutoMapper;
using Renature.Applications.Achievements.Responses;
using Renature.Infra.Entities.Achievements;

namespace Renature.Domain.Mappings;

public class AchievementMapping : Profile
{
    public AchievementMapping()
    {
        CreateMap<Achievement, AchievementResponse>();
    }
}