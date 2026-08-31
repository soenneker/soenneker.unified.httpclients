using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Unified.HttpClients.Abstract;

/// <summary>
/// Provides an authenticated HTTP client for the Unified API.
/// </summary>
public interface IUnifiedOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached HTTP client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">The token used to cancel client creation.</param>
    /// <returns>The authenticated HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
