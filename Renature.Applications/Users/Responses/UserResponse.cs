namespace Renature.Applications.Users.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Cpf { get; set; }
    public string Phone { get; set; }
    public int Level { get; set; }
    public int Points { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}