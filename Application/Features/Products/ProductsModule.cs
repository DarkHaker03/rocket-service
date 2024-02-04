using Application.Base.Interfaces;
using Application.Features.Products.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Products;

public class ProductsModule : IRegisterComponentModule
{
	public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
	{
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
	{
		services.AddScoped<ProductsService>();
		services.AddScoped<ProductActionsService>();
		services.AddScoped<ProductsInventorizationService>();
	}
}