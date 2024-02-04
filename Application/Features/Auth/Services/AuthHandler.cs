using Application.Features.Auth.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Features.Host.Options;

namespace Application.Features.Auth.Services;

public class AuthHandler(RequestDelegate next, IOptions<AuthOptions> options, IMemoryCache cache, IOptions<UwOptions> hostOptions)
{
	private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
	private readonly AuthOptions _options = options.Value;
	private readonly UwOptions _hostOptions = hostOptions.Value;
	private readonly IMemoryCache _cache = cache;
	private readonly RequestDelegate _next = next;

	public async Task InvokeAsync(HttpContext context)
	{

		if (context.Request.Path.StartsWithSegments(_hostOptions.MediaPath))
		{
			await _next.Invoke(context);
			return;
		}
		
		if (context.Request.Path.StartsWithSegments("/auth") || context.Request.Path.StartsWithSegments("/swagger"))
		{
			await _next.Invoke(context);
			return;
		}

		var token = context.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
			
		var validationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = _options.GetSecretKey(),
			ValidateIssuer = true,
			ValidateAudience = true,
			ClockSkew = TimeSpan.Zero,
			ValidIssuer = _options.Issuer,
			ValidAudience = _options.Audience
		};

		var validationResult = await _tokenHandler.ValidateTokenAsync(token, validationParameters);

		if (!validationResult.IsValid)
		{
			if (!context.Response.HasStarted)
			{
				context.Response.StatusCode = 403;
				await context.Response.WriteAsync("Unvalid token");
				return;
			}
		}

		var claims = GetClaims(token);

		var roleAttribute = context.GetEndpoint()!.Metadata.OfType<UwAuthorizeAttribute>().FirstOrDefault();

	
		if (roleAttribute != null && !roleAttribute.RequiredClaims.All(rc => claims.Claims.Any(x => x.Type == rc)))
		{
			context.Response.StatusCode = 403;
			await context.Response.WriteAsync("У вас нет досутпа к запрашиваемому ресурсу");
			return;
		}

		var userId = claims.Claims.First(q => q.Type == RUserClaimTypes.UserId);
		_cache.Set($"user_{userId}", claims, TimeSpan.FromMinutes(30));

		context.User = claims;

		await _next.Invoke(context);
	}

	private ClaimsPrincipal GetClaims(string Token)
	{
		var token = _tokenHandler.ReadToken(Token) as JwtSecurityToken;

		var claimsIdentity = new ClaimsIdentity(token.Claims, "Token");
		var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

		return claimsPrincipal;
	}

}

