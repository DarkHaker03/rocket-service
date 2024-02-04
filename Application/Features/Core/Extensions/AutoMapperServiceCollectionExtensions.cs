using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application.Base.Extensions;

public static class AutoMapperServiceCollectionExtensions
{
	public static IServiceCollection AddAutoMapperServices(this IServiceCollection services,
		Action<IMapperConfigurationExpression>? configure = null)
	{
		services.AddAutoMapper(cfg =>
		{
			cfg.AllowNullCollections = true;
			configure?.Invoke(cfg);
		}, Assembly.GetEntryAssembly());

		return services;
	}
}