using Application.Base.Services;
using Application.Features.Auth.Models;
using Application.Features.Auth.Options;
using Application.Features.Users.Services;
using Data;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Features.Auth.Services;

public class AuthService(RDbContext dbContext,
						IOptions<AuthOptions> options,
						UsersService usersService,
						IHttpContextAccessor httpContextAccessor) : BaseDbService(dbContext)
{
    private readonly AuthOptions _options = options.Value;
    private readonly UsersService _usersService = usersService;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
	

	public async Task Authenticate(AuthCreditinals creditinals, bool createIfNotExist = false)
    {
		var user = await _usersService.GetUserByEmail(creditinals.Email);

        if (user == null)
        {
			if (createIfNotExist)
			{
				user = await _usersService.CreateUser(new RUser
				{
					Email = creditinals.Email,
					Password = creditinals.Password,
				});
			}
			else
			{
				_httpContext.Response.StatusCode = 400;
				return;
			}
        }
		
		if (creditinals.Password != user.Password)
		{
			_httpContext.Response.StatusCode = 401;
			return;
		}
		
		var claims = new List<Claim> {
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(RUserClaimTypes.UserId, user.Id.ToString())};

		await _httpContext.Response.WriteAsync(GenerateBearerToken(claims));
	}

    private string GenerateBearerToken(List<Claim> claims)
    {
         var token = new JwtSecurityToken(
			issuer: _options.Issuer,
			audience: _options.Audience,
			claims: claims,
			expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_options.ExpiresIn)), 
			signingCredentials: new SigningCredentials(_options.GetSecretKey(), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
