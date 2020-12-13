namespace BillingApiTask.Models
{
    public class PaymentGatewayResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether the gateway result was successful or not.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the error message. Is set if processing was not successful.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
