using Application.Features.Auth;
using Application.Features.Users.Models;
using Application.Features.Users.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Users.Controllers;

[ApiController]
[Route("users")]
public class UsersController(UsersService usersService, IMapper mapper) : ControllerBase
{
    private readonly UsersService _usersService = usersService;
    private readonly IMapper _mapper = mapper;

	[HttpGet("me")]
	[UwAuthorize(RUserClaimTypes.UserId)]
    public async Task<UserModel> Me()
    {
       return _mapper.Map<UserModel>(await _usersService.GetUser());
    }
    
	[HttpPut("me")]
	[UwAuthorize(RUserClaimTypes.UserId)]
	public async Task<UserModel> MeUpdate(UpdateUserProfileModel model)
	{
		return _mapper.Map<UserModel>(await _usersService.UpdateProfile(model));
	}
}