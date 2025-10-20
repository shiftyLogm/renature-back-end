using Renature.Infra.Comuns;

namespace Renature.Infra.Entities.Users;

public class User : Entity
{
    public int Level { get; set; }
    public int Points { get; set; }
}