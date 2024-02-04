using Application.Base.Interfaces;
using Application.Features.Warehouse.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Warehouse;

public class WarehouseModule : IRegisterComponentModule
{
	public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
	{
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
	{
		services.AddScoped<WarehouseService>();
		services.AddScoped<StorageService>();
	}
}