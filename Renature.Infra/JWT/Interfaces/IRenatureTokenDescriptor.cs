using Microsoft.IdentityModel.Tokens;

namespace Renature.Infra.JWT.Interfaces;

public interface IRenatureTokenDescriptor
{
    SecurityTokenDescriptor GetDescriptor();
}