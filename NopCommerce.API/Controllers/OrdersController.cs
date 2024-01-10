using Contracts;
using Entities.Models.Customers;
using Entities.Models.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NopCommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICustomers _customerService;

        public OrdersController(ICustomers customerService)
        {
            _customerService = customerService;
        }

        // Endpoint for adding an order
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            var addedOrder = await _customerService.Addorder(order);
            return Ok(addedOrder);
        }

        // Endpoint for getting an order
        [HttpGet("{id}/{cusid}")]
        public async Task<IActionResult> GetOrder(int id, int cusid)
        {
            var order = await _customerService.Getorder(id, cusid);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // Endpoint for canceling an order
        [HttpDelete("{id}/{cusid}")]
        public async Task<IActionResult> CancelOrder(int id, int cusid)
        {
            await _customerService.Cancelorder(id, cusid);
            return NoContent();
        }
    }


    
}
