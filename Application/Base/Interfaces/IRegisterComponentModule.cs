using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Base.Interfaces;

/// <summary>
/// Интерфейс для регистрации сервисов в рамках отдельных компонентов.
/// </summary>
public interface IRegisterComponentModule
{
    public static abstract void ConfigureServices(IServiceCollection services, IConfiguration builderConfiguration);

    public static abstract void ConfigureOptions(IServiceCollection services, IConfiguration configuration);
}