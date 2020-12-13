using BillingApiTask.Models;
using BillingApiTask.Models.Configurations;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BillingApiTask.Services
{
    /// <summary>
    /// The <see cref="IStripeClient"/> implementation.
    /// </summary>
    public class StripeClient : IStripeClient
    {
        public StripeClient(IFlurlClientFactory flurlClientFactory, IOptions<StripeClientConfig> config)
        {
            _httpClient = flurlClientFactory.Get(config.Value.BaseUrl);
        }

        private readonly IFlurlClient _httpClient;

        public async Task<PaymentGatewayResult> ProcessBilling(OrderModel order)
        {
            await this._httpClient.BaseUrl
                .AppendPathSegment("post")
                .PostJsonAsync(order)
                .ReceiveJson<PaymentGatewayResult>();

            // Let's pretend we had a succsefull call.
            var response = new PaymentGatewayResult { Success = true };

            return response;
        }
    }
}
