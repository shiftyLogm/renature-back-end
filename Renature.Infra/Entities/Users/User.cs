using Microsoft.AspNetCore.Identity;

namespace Renature.Infra.Entities.Users;

public class User : IdentityUser<Guid>
{
    public string Cpf { get; set; }
    public string Phone { get; set; }
    public decimal Level { get; set; }
    public int Points { get; set; }
}