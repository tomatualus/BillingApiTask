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
    public class PayPalClientTests
    {
        public PayPalClientTests()
        {
            this.ServerMock = new ServerMock();
        }

        public ServerMock ServerMock { get; internal set; }

        public IFlurlClientFactory FlurlFactory => new PerBaseUrlFlurlClientFactory();

        public IOptions<PaypalClientConfig> PayPalClientConfig => Options.Create<PaypalClientConfig>(new PaypalClientConfig
        {
            BaseUrl = $"http://localhost:{this.ServerMock.Port}"
        });


        public IPayPalClient Client => new PayPalClient(this.FlurlFactory, this.PayPalClientConfig);

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
