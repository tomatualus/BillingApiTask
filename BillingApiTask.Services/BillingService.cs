using BillingApiTask.Models;
using System;
using System.Threading.Tasks;

namespace BillingApiTask.Services
{
    /// <summary>
    /// The <see cref="IBillingService"/> implementation.
    /// </summary>
    public class BillingService : IBillingService
    {
        public BillingService(
            IPayPalClient paypalClient,
            IStripeClient stripeClient)
        {
            this._paypalClient = paypalClient;
            this._stripeClient = stripeClient;
        }

        private readonly IPayPalClient _paypalClient;

        private readonly IStripeClient _stripeClient;

        public async Task<PaymentGatewayResult> ProcessOrder(OrderModel order)
        {
            var result = new PaymentGatewayResult();

            result = order.PaymentGateway switch
            {
                PaymentGateway.PayPal => result = await this._paypalClient.ProcessBilling(order),
                PaymentGateway.Stripe => result = await this._stripeClient.ProcessBilling(order),
                _ => throw new ArgumentException("Unexpected Gateway", nameof(order.PaymentGateway)),
            };

            return result;
        }
    }
}
