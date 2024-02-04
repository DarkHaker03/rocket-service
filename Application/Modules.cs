using Application.Base.Interfaces;
using Application.Features.Auth;
using Application.Features.Bills;
using Application.Features.Documents;
using Application.Features.Host;
using Application.Features.Products;
using Application.Features.Users;
using Application.Features.Warehouse;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public class Modules : IRegisterComponentModule
{
	public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
	{
		AuthModule.ConfigureOptions(services, configuration);
		DocumentsModule.ConfigureOptions(services, configuration);
		FilesModule.ConfigureOptions(services, configuration);
		CoreModule.ConfigureOptions(services,configuration);
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
    {
        UsersModule.ConfigureServices(services, builderConfiguration);
		AuthModule.ConfigureServices(services, builderConfiguration);
		ProductsModule.ConfigureServices(services, builderConfiguration);
		BillsModule.ConfigureServices(services,builderConfiguration);
		WarehouseModule.ConfigureServices(services, builderConfiguration);
		DocumentsModule.ConfigureServices(services, builderConfiguration);
		FilesModule.ConfigureServices(services, builderConfiguration);
		CoreModule.ConfigureServices(services, builderConfiguration);
	}
}