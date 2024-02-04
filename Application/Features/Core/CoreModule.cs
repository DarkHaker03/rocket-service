using Application.Base.Extensions;
using Application.Base.Interfaces;
using Application.Features.Auth.Services;
using Application.Features.Bills.Mappings;
using Application.Features.Documents.Mappings;
using Application.Features.Host.Mappings;
using Application.Features.Host.Options;
using Application.Features.Products.Mappings;
using Application.Features.Users.Mappigns;
using Application.Features.Warehouse.Mappings;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Host;

public class CoreModule : IRegisterComponentModule
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration)
    {
        services.AddTransient<ProblemDetailsFactory ,UwProblemDetailsFactory>();
        
       
    }

    public static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions()
            .Configure<UwOptions>(options => configuration.GetSection(UwOptions.Key).Bind(options));
    }
}