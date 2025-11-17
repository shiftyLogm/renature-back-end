using NpgsqlTypes;
using Renature.Infra.Comuns;

namespace Renature.Infra.Entities.Stores;

public class Store : Entity
{
    public string Name { get; set; }
    public NpgsqlPoint Coordinates { get; set; }
}