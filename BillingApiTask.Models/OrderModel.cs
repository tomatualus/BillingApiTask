using BillingApiTask.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace BillingApiTask.Models
{
    public class OrderModel
    {
        /// <summary>
        /// Gets or sets the Number. Used for database queries.
        /// </summary>
        [Required(ErrorMessage = "No Number provided.")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the UserId. Used to get information about User.
        /// </summary>
        [Required(ErrorMessage = "No UserId provided.")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the payable amount.
        /// </summary>
        [Required(ErrorMessage = "No PayableAmount provided.")]
        public double PayableAmount { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Currency"/> value. Used to convert the payable amount.
        /// </summary>
        [RequiredEnum(ErrorMessage = "No valid Currency specified.")]
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="PaymentGateway"/> value. Used to determine which gateway client to use.
        /// </summary>
        [RequiredEnum(ErrorMessage = "No valid PaymentGateway specified.")]
        public PaymentGateway PaymentGateway { get; set; }

        /// <summary>
        /// Gets or sets the optional description for the order.
        /// </summary>
        public string Description { get; set; }
    }
}
