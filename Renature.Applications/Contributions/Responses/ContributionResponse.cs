using Renature.Infra.Entities.Contributions.Enums;

namespace Renature.Applications.Contributions.Responses;

public class ContributionResponse
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public WasteType WasteType { get; set; }
    public string Product { get; set; }
    public decimal Quantity { get; set; }
    public int AdquiredPoints { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}