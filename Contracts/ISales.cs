using Entities.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Models.Sales.Order;

namespace Contracts
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetOrder();
        Task<Order> GetOrder(int ID);
        //Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrderStatus(int orderId, OrderStatus orderStatus);      
        Task DeleteOrder(int ID);
    }
    public interface IReturnRequest 
    {
        Task<IEnumerable<ReturnRequest>> GetReturnReq();
       
    }
}
