using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Renature.Infra.JWT.Interfaces;

namespace Renature.Infra.JWT;

public class RenatureTokenDescriptor : IRenatureTokenDescriptor
{
    private readonly IConfiguration _configuration;

    public RenatureTokenDescriptor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SecurityTokenDescriptor GetDescriptor()
    {
        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

        return new SecurityTokenDescriptor
        {
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
    }
}