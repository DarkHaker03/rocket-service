using Application.Base.Interfaces;
using Application.Features.Host.Options;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Host;

public class CoreModule : IRegisterComponentModule
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
    {
        services.AddTransient<ProblemDetailsFactory ,RProblemDetailsFactory>();
    }

    public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions()
            .Configure<UwOptions>(options => configuration.GetSection(UwOptions.Key).Bind(options));
    }
}