using Application.Features.Auth.Models;
using Application.Features.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Features.Auth.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(AuthService authService)
{
	private readonly AuthService _authService = authService;

	[HttpPost("login")]
	[ProducesResponseType(200, Type = typeof(string))]
	[ProducesResponseType(400)]
	public async Task Login([FromBody] AuthCreditinals creditinals)
    {	
		await _authService.Authenticate(creditinals);
    }

	[HttpPost("registration")]
	[ProducesResponseType(200, Type = typeof(string))]
	public async Task Register(AuthCreditinals creditinals)
	{
		await _authService.Authenticate(creditinals, true);
	}
}

