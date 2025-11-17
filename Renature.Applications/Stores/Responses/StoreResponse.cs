using NpgsqlTypes;

namespace Renature.Applications.Stores.Responses;

public class StoreResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public NpgsqlPoint Coordinates { get; set; }
}