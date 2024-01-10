using Entities.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Contracts.ICatalog;

namespace NOP.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet("GetCategory")]
        public async Task<IEnumerable<Categories>> GetProducts()
        {
            var categories = await categoryRepository.GetCategories();
            return categories;

        }

        [HttpGet("GetCategory by ID")]
        public async Task<IEnumerable<Categories>> GetProductsbyid(int id)
        {
            var category = await categoryRepository.GetCategorybyId(id);
            return null;

        }


        [HttpPost("Add Categories")]
        public async Task<ActionResult<Categories>> SaveEmployee(Categories categories)
        {

            if (categories != null)
            {
                categories.Id = 0;
                await categoryRepository.AddCategories(categories);
            }

            return categories;
        }
        [HttpPut("Update Categories/{id}")]
        public async Task<ActionResult<Categories>> UpdateCategory(Categories categories)
        {
            var UpdatedCategories = await categoryRepository.UpdateCategories(categories);
            return UpdatedCategories;

        }
        [HttpDelete("Delete")]

        public async Task<IActionResult> DeleteCategory(int ID)
        {
            //var CategoryToDelete = await categoryRepository.DeleteCategories(ID);


            await categoryRepository.DeleteCategories(ID);
            return NoContent();



        }
    }
}
