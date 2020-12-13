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
    /// The <see cref="IPayPalClient"/> implementation.
    /// </summary>
    public class PayPalClient : IPayPalClient
    {
        public PayPalClient(IFlurlClientFactory flurlClientFactory, IOptions<PaypalClientConfig> config)
        {
            _httpClient = flurlClientFactory.Get(config.Value.BaseUrl);
        }

        private readonly IFlurlClient _httpClient;

        public async Task<PaymentGatewayResult> ProcessBilling(OrderModel order)
        {
            await this._httpClient.BaseUrl
                .AppendPathSegment("post")
                .PostJsonAsync(order)
                .ReceiveJson();

            // Let's pretend we had a succsefull call.
            var response = new PaymentGatewayResult { Success = true };

            return response;
        }
    }
}
