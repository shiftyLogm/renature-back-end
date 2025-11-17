using Renature.Infra.Entities.Contributions.Enums;

namespace Renature.Applications.Contributions.Requests;

public class ContributionRequest
{
    public string UserId { get; set; }
    public WasteType WasteType { get; set; }
    public string Product { get; set; }
    public decimal Quantity { get; set; }
    public int AdquiredPoints { get; set; }
}
