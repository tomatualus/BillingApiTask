using System;

namespace BillingApiTask.Models
{
    public class ReceiptModel
    {
        /// <summary>
        /// Gets or sets the datem when receipt was generated.
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PaymentGateway"/> used in orders processing.
        /// </summary>
        public PaymentGateway GatewayUsed { get; set; }

        /// <summary>
        /// Gets or sets the amount spent.
        /// </summary>
        public double AmountSpent { get; set; }

        /// <summary>
        /// Gets or sets a system wide static message to display at the bottom of the receipt.
        /// </summary>
        public string MessageFromSystem { get; set; }
    }
}
