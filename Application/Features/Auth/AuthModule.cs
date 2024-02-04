using Application.Base.Interfaces;
using Application.Features.Auth.Options;
using Application.Features.Auth.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Application.Features.Auth;

public class AuthModule : IRegisterComponentModule
{
	public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
	{
		services.AddOptions()
			.Configure<AuthOptions>(options => configuration.GetSection(AuthOptions.Key).Bind(options));
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
	{
		services.AddScoped<AuthService>();
		services.AddScoped<UserIdentity>();
		services.AddScoped<ClaimsPrincipal>(_ => ClaimsPrincipal.Current);
	}

}
