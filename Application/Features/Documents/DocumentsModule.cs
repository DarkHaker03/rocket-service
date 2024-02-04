using Application.Base.Interfaces;
using Application.Features.Documents.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Features.Documents;

public class DocumentsModule : IRegisterComponentModule
{
	public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
	{
	}

	public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
	{
		services.AddScoped<ExcelService>();
		services.AddScoped<DocxService>();
		services.AddScoped<DocumentsService>();
	}
}
