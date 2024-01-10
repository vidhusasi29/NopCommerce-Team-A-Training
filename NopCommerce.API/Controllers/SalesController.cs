using Contracts;
using Entities.Models.Promotions;
using Entities.Models.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Entities.Models.Sales.Order;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NOP.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IOrder _order;
        private readonly IReturnRequest _return;

        public SalesController(IOrder order, IReturnRequest returnReq)
        {
            _order = order;
            _return = returnReq;
        }

        // Order
        [HttpGet("GetOrders")]
        public async Task<IEnumerable<Order>> GetOrderAsync()
        {
            var get = await _order.GetOrder();
            return get;
        }

        // GET api/<ValuesController>/5
        [HttpGet("GetOrderById")]
        public async Task<Order> GetOrderById(int id)
        {
            var get = await _order.GetOrder(id);
            return get;
        }

               

        [HttpPut("Update-OrderStatus")]
        public async Task<Order> UpdateOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var update = await _order.UpdateOrderStatus(orderId,orderStatus);
            return update;
        }

        
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _order.DeleteOrder(id);
            return NoContent();
        }
        // ReturnRequest
        [HttpGet("Display-ReturnRequest")]
        public async Task<IEnumerable<ReturnRequest>> GetReturn()
        {
            var get = await _return.GetReturnReq();
            return get;
        }
    }
}
