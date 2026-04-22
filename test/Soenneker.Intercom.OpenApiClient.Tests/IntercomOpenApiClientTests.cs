using Soenneker.Tests.HostedUnit;

namespace Soenneker.Intercom.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class IntercomOpenApiClientTests : HostedUnitTest
{
    public IntercomOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
