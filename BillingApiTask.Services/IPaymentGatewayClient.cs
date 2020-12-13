using BillingApiTask.Models;
using System.Threading.Tasks;

namespace BillingApiTask.Services
{
    /// <summary>
    /// The common payment gateway client contract.
    /// </summary>
    public interface IPaymentGatewayClient
    {
        /// <summary>
        /// Handles billing to a gateway client.
        /// </summary>
        /// <param name="order">The <see cref="OrderModel"/> that contains the billing information.</param>
        /// <returns>The payment result.</returns>
        Task<PaymentGatewayResult> ProcessBilling(OrderModel order);
    }
}
