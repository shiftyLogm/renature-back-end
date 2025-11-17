namespace Renature.Applications.Users.Requests;

public class UserRegister
{
    public string UserName { get; set; }
    public string Cpf { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}