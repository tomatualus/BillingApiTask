using BillingApiTask.Models;
using BillingApiTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BillingApiTask.Models.Helpers;

namespace BillingApiTask.BillingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BillingController"/>.
        /// </summary>
        /// <param name="billingService"></param>
        public BillingController(IBillingService billingService)
        {
            this.billingService = billingService;
        }

        private readonly IBillingService billingService;

        /// <summary>
        /// Processes the incoming <see cref="OrderModel"/> and returns <see cref="ReceiptModel"/> if processing was succesfull.
        /// </summary>
        /// <param name="order"></param>
        /// <returns>The <see cref="ReceiptModel"/> calculated according to incoming <see cref="OrderModel"/>.</returns>
        [HttpPost]
        public async Task<ReceiptModel> Post([FromBody] OrderModel order)
        {
            await billingService.ProcessOrder(order);
            ReceiptModel receipt = order.CreateReceipt();

            return receipt;
        }
    }
}
