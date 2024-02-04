using Application.Base.Interfaces;
using Application.Features.Users.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Users;

public class UsersModule : IRegisterComponentModule
{
	public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
	{
	
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
    {
        services.AddScoped<UsersService>();
    }
}