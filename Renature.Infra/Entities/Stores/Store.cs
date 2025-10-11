using NpgsqlTypes;

namespace Renature.Infra.Entities.Stores;

public class Store
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public NpgsqlPoint Coordinates { get; set; }
}