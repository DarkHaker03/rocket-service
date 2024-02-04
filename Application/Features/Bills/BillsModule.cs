using Application.Base.Interfaces;
using Application.Features.Bills.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Bills;

public class BillsModule : IRegisterComponentModule
{
	public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
	{
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
	{
		services.AddScoped<BillsService>();
	}
}
