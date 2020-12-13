using System;

namespace BillingApiTask.Models.Helpers
{
    /// <summary>
    /// Helpful extensions for <see cref="OrderModel"/>.
    /// </summary>
    public static class OrderExtensions
    {
        /// <summary>
        /// Creates a <see cref="ReceiptModel"/> from the given <see cref="OrderModel"/>.
        /// </summary>
        /// <param name="order">The <see cref="OrderModel"/>.</param>
        /// <returns></returns>
        public static ReceiptModel CreateReceipt(this OrderModel order)
        {
            return new ReceiptModel
            {
                Date = DateTimeOffset.UtcNow,
                AmountSpent = order.PayableAmount,
                GatewayUsed = order.PaymentGateway,
                MessageFromSystem = "Please come again!"
            };
        }
    }
}
