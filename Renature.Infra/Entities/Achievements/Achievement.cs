namespace Renature.Infra.Entities.Achievements;

public class Achievement
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}