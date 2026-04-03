using Soenneker.Unified.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Unified.HttpClients.Tests;

[Collection("Collection")]
public sealed class UnifiedOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IUnifiedOpenApiHttpClient _httpclient;

    public UnifiedOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IUnifiedOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
