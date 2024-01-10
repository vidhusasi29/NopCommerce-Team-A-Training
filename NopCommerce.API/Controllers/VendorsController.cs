using Contracts;
using Entities.Models.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NOP.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendors _vendor;
        public VendorsController(IVendors _vendor)
        {
            this._vendor = _vendor;
            
        }
        [HttpPost("Vendor Registration")]
        public async Task<Vendors> Addnewvendor(Vendors vendor)
        {
            Vendors vendorobj = new Vendors();  
            if (vendor != null)
            {
                vendor.Id = 0;
                vendorobj = await _vendor.AddVendor(vendor);
            }

            return vendorobj;
        }


        [HttpGet("Search Vendor By Id")]
        public async Task<ActionResult<Vendors>> GetVendorByID(int id)
        {
            var Vendor = await _vendor.Getvendor(id);
            return Vendor;
        }

        [HttpPut("Edit Vendor details")]
        public async Task<ActionResult<Vendors>> UpdateVendor(int id, Vendors vendor)
        {
            if (id != vendor.Id)
            {
                return BadRequest("vendor ID mismatch.");
            }

            var existingvendor = await _vendor.Getvendor(id);

            if (existingvendor == null)
            {
                return NotFound($"Vendor with ID {id} not found.");
            }

         
                var updatedvendor = await _vendor.UpdateVendor(vendor);

            return updatedvendor;
           
        }
        [HttpDelete("Delete Vendor")]
        public async Task<IActionResult> Deletevendor(int id)
        {
            var VendorToDelete = await _vendor.Getvendor(id);

            if (VendorToDelete == null)
            {
                return NotFound($"Vendor with ID {id} not found.");
            }

            await _vendor.DeleteVendor(id);
            return NoContent();
        }




    }
}
