using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Unified.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Unified.HttpClients.Registrars;

/// <summary>
/// Registers authenticated HTTP clients for the Unified API.
/// </summary>
public static class UnifiedOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="UnifiedOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddUnifiedOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IUnifiedOpenApiHttpClient, UnifiedOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="UnifiedOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddUnifiedOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IUnifiedOpenApiHttpClient, UnifiedOpenApiHttpClient>();

        return services;
    }
}
