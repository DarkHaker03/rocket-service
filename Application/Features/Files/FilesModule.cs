using Application.Base.Interfaces;
using Application.Features.Files.Options;
using Application.Features.Files.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Documents;

public class FilesModule : IRegisterComponentModule
{
	public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
	{
		services.AddOptions()
			.Configure<FilesOptions>(options => configuration.GetSection(FilesOptions.Key).Bind(options));
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
	{
		services.AddScoped<FilesService>();
	}
}
