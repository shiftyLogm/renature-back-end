using AutoMapper;
using Renature.Applications.Users.Requests;
using Renature.Applications.Users.Responses;
using Renature.Infra.Entities.Users;

namespace Renature.Domain.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserRegister, User>();
        CreateMap<User, UserResponse>();
    }
}