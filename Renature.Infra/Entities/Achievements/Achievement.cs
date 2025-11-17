using Renature.Infra.Comuns;

namespace Renature.Infra.Entities.Achievements;

public class Achievement : Entity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int? NecessaryLevel { get; set; }
}