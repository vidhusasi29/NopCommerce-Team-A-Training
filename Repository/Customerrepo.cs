using Contracts;
using Entities.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models.Customers;
using Entities.Models.Sales;
//using Microsoft.AspNetCore.Mvc;
using System.Net;
using Entities.Models.Sales;
using Microsoft.AspNetCore.Mvc;



namespace Repository
{
    public class Customerrepo : ICustomers, IAddress, IVendors
    {
        private readonly ContextDB Customercontext;
        public Customerrepo(ContextDB Customercontext)
        {
            this.Customercontext = Customercontext;
        }
        public async Task<Address> addaddress(Address address)
        {
            var result =
                await Customercontext.Address
                .AddAsync(address);
            await Customercontext.SaveChangesAsync();
            return result.Entity;
        }
        async Task<Address> IAddress.Updateaddress(Address address)
        {
            var result = await Customercontext.Address
            .Where(e => e.Customer_ID == address.Customer_ID)
                    .FirstOrDefaultAsync();
            if (result != null)
            {

                result.Addresses = address.Addresses;
                result.State = address.State;
                result.City = address.City;
                result.County = address.County;

                result.Postal_code = address.Postal_code;
                result.Phone_number = address.Phone_number;



                await Customercontext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<CustomerRegistration> AddCustomer(CustomerRegistration customer)
        {
            var result = await Customercontext.CustomerRegistration.AddAsync(customer);
            await Customercontext.SaveChangesAsync();
            return result.Entity;
        }


        async Task<CustomerRegistration> ICustomers.GetCustomer(int customerid)
        {
            return await Customercontext.CustomerRegistration
                      .FirstOrDefaultAsync(e => e.Id == customerid);
        }
        public async Task<CustomerRegistration> UpdateCustomer(CustomerRegistration customer)
        {
            var result = await Customercontext.CustomerRegistration
                 .FirstOrDefaultAsync(e => e.Id == customer.Id);

            if (result != null)
            {
                result.Email = customer.Email;
                result.Password = customer.Password;
                result.First_name = customer.First_name;
                result.Last_name = customer.Last_name;


                await Customercontext.SaveChangesAsync();

                return result;
            }

            return null;
        }


        async Task<IActionResult> ICustomers.DeleteCustomer(int customerid)
        {
            var result = await Customercontext.CustomerRegistration
                .FirstOrDefaultAsync(e => e.Id == customerid);
            if (result != null)
            {
                Customercontext.CustomerRegistration.Remove(result);
                await Customercontext.SaveChangesAsync();

            }
            return null;
            


        }


        public async Task<Vendors> AddVendor(Vendors vendor)
        {
            if (vendor != null)
            {
                var result = await Customercontext.Vendors.AddAsync(vendor);
                await Customercontext.SaveChangesAsync();
                return result.Entity;
            }
            else
            {
                return null; // or throw an exception, depends on your use case
            }
        }
        public async Task<IActionResult> DeleteVendor(int vendorid)
        {
            var result = await Customercontext.Vendors
                .FirstOrDefaultAsync(e => e.Id == vendorid);
            if (result != null)
            {
                Customercontext.Vendors.Remove(result);
                await Customercontext.SaveChangesAsync();

            }
            return null;
            
        }

        public async Task<Vendors> Getvendor(int vendorid)
        {
            return await Customercontext.Vendors
                      .FirstOrDefaultAsync(e => e.Id == vendorid);
        }





        public async Task<Vendors> UpdateVendor(Vendors vendor)
        {
            var result = await Customercontext.Vendors
                 .FirstOrDefaultAsync(e => e.Id == vendor.Id);

            if (result != null)
            {
                result.Name = vendor.Name;
                result.Company_name = vendor.Company_name;
                result.Address = vendor.Address;
                result.State = vendor.State;
                result.City = vendor.City;
                result.Region = vendor.Region;
                result.Country = vendor.Country;
                result.Zip = vendor.Zip;
                result.Phone_number = vendor.Phone_number;


                await Customercontext.SaveChangesAsync();

                return result;
            }

            return null;
        }



        public async Task<Order> Addorder(Order orders)
        {
            var result = await Customercontext.Orders.AddAsync(orders);
            await Customercontext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Order> Getorder(int id, int cusid)
        {
            return await Customercontext.Orders
           .Where(e => e.ID == id && e.CustomerRegistrationid == cusid)
           .FirstOrDefaultAsync();


        }

        
      async  Task<IActionResult> ICustomers.Cancelorder(int id, int cusid)
        {
            var result = await Customercontext.Orders
           .Where(e => e.ID == id && e.CustomerRegistrationid == cusid)
           .FirstOrDefaultAsync();
            if (result != null)
            {
                Customercontext.Orders.Remove(result);
                await Customercontext.SaveChangesAsync();

            }
            return null;
        }
    }
}


