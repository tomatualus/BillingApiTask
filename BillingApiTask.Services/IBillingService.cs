using BillingApiTask.Models;
using System.Threading.Tasks;

namespace BillingApiTask.Services
{
    /// <summary>
    /// The billing service contract.
    /// </summary>
    public interface IBillingService
    {
        /// <summary>
        /// Processes the incoming <see cref="OrderModel"/>.
        /// </summary>
        /// <param name="order">The <see cref="OrderModel"/> to process.</param>
        /// <returns>Result of the gateway processing.</returns>
        Task<PaymentGatewayResult> ProcessOrder(OrderModel order);
    }
}
