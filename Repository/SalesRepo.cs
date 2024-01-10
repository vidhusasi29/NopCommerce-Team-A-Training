using Contracts;
using Entities.Models;
using Entities.Models.Catalog;
using Entities.Models.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Models.Sales.Order;

namespace Repository
{
    public class SalesRepo : IOrder, IReturnRequest
    {
        private readonly ContextDB _context;
        public SalesRepo(ContextDB context)
        {
            this._context = context;
        }

        /* public async Task<Order> AddOrder(Order order)
         {
             var result = await this._context.Orders.AddAsync(order);
             await this._context.SaveChangesAsync();
             return result.Entity;
         }*/

        public async Task DeleteOrder(int ID)
        {
            var result = await _context.Orders
                .FirstOrDefaultAsync(o => o.ID == ID);
            if (result != null)
            {
                _context.Orders.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrder(int ID)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.ID == ID);
        }


        public async Task<Order> UpdateOrderStatus(int orderId, OrderStatus orderStatus)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.ID == orderId);

            if (order != null)
            {
                order.OStatus = orderStatus;                
                await _context.SaveChangesAsync();
                return order;
            }

            return null;
        }
        //ReturnRequest
        public async Task<IEnumerable<ReturnRequest>> GetReturnReq()
        {
            return await _context.ReturnRequest.ToListAsync();
        }
        //Shipments      
        public async Task<IEnumerable<Shipments>> GetShipment()
        {
            return await _context.Shipments.ToListAsync();
        }

        public async Task<Shipments> UpdateShipment(Shipments shipments)
        {
            var result = await _context.Shipments
                 .FirstOrDefaultAsync(M => M.Id == shipments.Id);

            if (result != null)
            {
                result.StartDate = shipments.StartDate;
                result.EndDate = shipments.EndDate;
                return result;
            }
            return null;

        }
            
    }
}
