using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Intercom.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class IntercomOpenApiClientTests : FixturedUnitTest
{
    public IntercomOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
