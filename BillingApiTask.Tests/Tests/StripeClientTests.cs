using BillingApiTask.Models;
using BillingApiTask.Models.Configurations;
using BillingApiTask.Services;
using FluentAssertions;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Xunit;

namespace BillingApiTask.Tests.Tests
{
    public class StripeClientTests
    {
        public StripeClientTests()
        {
            this.ServerMock = new ServerMock();
        }

        public ServerMock ServerMock { get; internal set; }

        public IFlurlClientFactory FlurlFactory => new PerBaseUrlFlurlClientFactory();

        public IOptions<StripeClientConfig> StripeClientConfig => Options.Create<StripeClientConfig>(new StripeClientConfig
        {
            BaseUrl = $"http://localhost:{this.ServerMock.Port}"
        });


        public IStripeClient Client => new StripeClient(this.FlurlFactory, this.StripeClientConfig);

        [Fact]
        public async Task CorrectlyReceivesData()
        {
            ServerMock.MockSuccesfullClientResponse("123");
            PaymentGatewayResult result = await this.Client.ProcessBilling(
                new OrderModel
                {
                    Number = "123"
                });

            result.Should().NotBeNull()
                .And.BeEquivalentTo(new PaymentGatewayResult { Success = true });
        }
    }
}
