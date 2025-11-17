using Renature.Infra.Comuns;
using Renature.Infra.Entities.Contributions.Enums;
using Renature.Infra.Entities.Users;

namespace Renature.Infra.Entities.Contributions;

public class Contribution : Entity
{
    public Guid UserId { get; set; }
    public WasteType WasteType { get; set; }
    public string Product { get; set; }
    public decimal Quantity { get; set; }
    public int AdquiredPoints { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;

    #region Foreign Keys

    public User User { get; set; }

    #endregion
}