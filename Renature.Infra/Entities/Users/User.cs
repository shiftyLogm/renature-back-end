using Microsoft.AspNetCore.Identity;

namespace Renature.Infra.Entities.Users;

public class User : IdentityUser
{
    public string Cpf { get; set; }
    public string Phone { get; set; }
    public int Level { get; set; }
    public int Points { get; set; }
}