using Contracts;
using Entities.Models.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
//using Entities.Models.Sales;

namespace NOP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRegController : ControllerBase
    {
        private readonly ICustomers _customer;
        
        private readonly IAddress _address;
        public CustomerRegController(ICustomers _customer, IVendors _vendor, IAddress _address)
        {
            this ._customer = _customer;
           
            this._address = _address;
            
        }

        [HttpPost("Customer Registration")]
        public async Task<CustomerRegistration> Addnewcustomer(CustomerRegistration customer)
        {
            CustomerRegistration reg= new CustomerRegistration();
            if (customer != null)
            {
               customer.Id = 0;
                reg = await _customer.AddCustomer(customer);
            }

            return reg;
        }


        [HttpGet("Search Customer By Id")]
        public async Task<ActionResult<CustomerRegistration>> GetCustomerByID(int id)
        {
            var customers = await _customer.GetCustomer(id);
            return customers;
        }

        [HttpPut("Edit Customer details")]
        public async Task<ActionResult<CustomerRegistration>> UpdateCustomer(int id, CustomerRegistration customer)
        {
            if (id != customer.Id)
            {
                return BadRequest("Customer ID mismatch.");
            }

            var existingCustomer = await _customer.GetCustomer(id);

            if (existingCustomer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

            var updatedCustomer = await _customer.UpdateCustomer(customer);
            return updatedCustomer;
        }
        [HttpDelete("Delete Customer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customerToDelete = await _customer.GetCustomer(id);

            if (customerToDelete == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }

            await _customer.DeleteCustomer(id);
            return NoContent();
        }

        [HttpPost("Add new address")]
        public async Task<Address> Addnewaddress(Address address)
        {
           Address addressobj = new Address();
            if ( address!= null)
            {
                address.Id = 0;
                addressobj = await _address.addaddress( address);
            }

            return addressobj;
        }
        [HttpPut("Edit Customer Address")]
        public async Task<ActionResult<Address>> UpdateAddress( Address address)
        {

            

            var updatedaddress = await _address.Updateaddress(address);
            return updatedaddress;
        }

        //[HttpPost("New Order")]
        //public async Task<Order> Addneworder(Order order)
        //{
        //    Order orderobj = new Order();
        //    if (order != null)
        //    {
        //        order.ID = 0;
        //        orderobj = await _customer.Addorder(order);
        //    }

        //    return orderobj;
        //}


        //[HttpGet("Search Order By ID")]
        //public async Task<ActionResult<Order>> Getorder(int id, int cusid)
        //{
        //    var orders = await _customer.Getorder(id, cusid);
        //    return orders;
        //}
        //[HttpDelete("Delete Order")]
        //public async Task<IActionResult> Cancelorder(int id, int cusid)
        //{
        //    var OrdertoDelete = await _customer.Getorder(id, cusid);

        //    if (OrdertoDelete == null)
        //    {
        //        return NotFound($"Order not found.");
        //    }

        //    await _customer.Cancelorder(id, cusid);
        //    return NoContent();
        //}

    }
}
