using Entities.Models.Customers;
using Entities.Models.Sales;
using Microsoft.AspNetCore.Mvc;

//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts
{
    public partial interface ICustomers
    {


        Task<CustomerRegistration> GetCustomer(int customerid);
        Task<CustomerRegistration> AddCustomer(CustomerRegistration customer);
        Task<CustomerRegistration> UpdateCustomer(CustomerRegistration customer);
        Task<IActionResult> DeleteCustomer(int customerid);
        Task<Order> Addorder(Order orders);
        Task<Order> Getorder(int id, int cusid);
        Task<IActionResult> Cancelorder(int id, int cusid);


    }
    public partial interface IAddress
    {


        Task<Address> addaddress(Address address);
        Task<Address> Updateaddress(Address address);
    }
    public partial interface IVendors
    {


        Task<Vendors> Getvendor(int vendorid);
        Task<Vendors> AddVendor(Vendors vendor);
        Task<Vendors> UpdateVendor(Vendors vendor);
        Task<IActionResult> DeleteVendor(int vendorid);
    }

}
