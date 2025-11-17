using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Renature.Applications.Users.Interfaces;
using Renature.Applications.Users.Requests;
using Renature.Applications.Users.Responses;
using Renature.Infra.Entities.Users;
using Renature.Infra.Entities.UsersAchievements;
using Renature.Infra.Entities.UsersAchievements.Interfaces;
using Renature.Infra.JWT.Interfaces;

namespace Renature.Applications.Users.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IRenatureTokenDescriptor _tokenDescriptor;
    private readonly IUserAchievementRepository _userAchievementRepository;
    
    public UserService(
        UserManager<User> userManager,
        IRenatureTokenDescriptor tokenDescriptor,
        IUserAchievementRepository userAchievementRepository,
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
        _tokenDescriptor =  tokenDescriptor;
        _userAchievementRepository = userAchievementRepository;
    }

    public async Task<IActionResult> Register(UserRegister request, ControllerBase controller)
    {
        if (!controller.ModelState.IsValid)
            return controller.BadRequest(controller.ModelState);

        var user = _mapper.Map<User>(request);

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return controller.BadRequest(result.Errors);

        var jwtToken = GenerateJwt(user);
        
        return controller.Ok(jwtToken);
    }

    public async Task<IActionResult> Login(UserLogin request, ControllerBase controller)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null) return controller.Unauthorized();
        
        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid) return controller.Unauthorized();
        
        var jwtToken = GenerateJwt(user);
        
        return controller.Ok(jwtToken);
    }

    public async Task<ActionResult<UserResponse>> GetUserById(Guid id, ControllerBase controller)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null) return controller.NotFound();
        
        return controller.Ok(_mapper.Map<UserResponse>(user));
    }

    public ActionResult<List<UserAchievement>> GetAchievementsByUserId(Guid userId, ControllerBase controller)
    {
        var achievements = _userAchievementRepository.GetAll(userId);
        
        if (!achievements.Any()) return controller.NoContent();
        
        var result = achievements.ToList();
        
        return controller.Ok(result);
    }

    private string GenerateJwt(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var descriptor = _tokenDescriptor.GetDescriptor();
        
        descriptor.Subject = new ClaimsIdentity(new[]
        {
            new Claim("userId", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName)
        });
        
        var token = tokenHandler.CreateToken(descriptor);
        var strToken = tokenHandler.WriteToken(token);
        return strToken;
    }
}
