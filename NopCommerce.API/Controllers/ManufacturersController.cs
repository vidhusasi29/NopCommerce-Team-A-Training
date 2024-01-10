using Entities.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using static Contracts.ICatalog;

namespace NOP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerRepository manufacturerRepository;

        public ManufacturersController(IManufacturerRepository manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;

        }
        [HttpGet("GetManufacturers")]
        public async Task<IEnumerable<Manufacturers>> GetManufacturers()
        {
            var manufacturers = await manufacturerRepository.GetManufacturer();
            return manufacturers;

        }
        [HttpGet("Search Manufacturer By Id")]
        public async Task<ActionResult<Manufacturers>> GetManufacturerByID(int id)
        {
            var manufacturers = await manufacturerRepository.GetManufacturerbyId(id);
            return manufacturers;
        }
        [HttpPost("Add Manufacturers")]


        public async Task<ActionResult<Manufacturers>> AddManufacturers(Manufacturers manufacturers)
        {
            //Manufacturers manufacturers1 = new Manufacturers();
            if (manufacturers != null)
            {
                manufacturers.Id = 0;
                await manufacturerRepository.AddManufacturers(manufacturers);
            }

            return manufacturers;
        }
        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult<Manufacturers>> UpdatManufacturers(Manufacturers manufacturers)
        {
            var Updatedmanufacturers = await manufacturerRepository.UpdateManufacturers(manufacturers);
            return Updatedmanufacturers;

        }
        [HttpDelete("Delete/{id}")]

        public async Task<IActionResult> DeleteManufacturers(int ID)
        {
            await manufacturerRepository.DeleteManufacturers(ID);
            return NoContent();

        }

    }
}
