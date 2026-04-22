using Soenneker.Unified.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Unified.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class UnifiedOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IUnifiedOpenApiHttpClient _httpclient;

    public UnifiedOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IUnifiedOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
