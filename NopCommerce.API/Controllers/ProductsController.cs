using Entities.Models.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Contracts.ICatalog;

namespace NOP.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("Get Products")]
        public async Task<IEnumerable<Products>> GetProducts()
        {
            var pro = await productRepository.GetProducts();
            return pro;
        }

        [HttpGet("Get Products by ID")]
        public async Task<Products> GetProductbyId(int Id)
        {
            var pro = await productRepository.GetProductbyId(Id);
            return pro;
        }

        [HttpPost("Add Products")]
        public async Task<Products> AddProducts(Products products)
        {
            Products obj = new Products();
            if (products != null)
            {
                obj = await productRepository.AddProducts(products);
            }
            return obj;
        }

        [HttpPut("Update Products")]
        public async Task<Products> UpdateProducts(Products products)
        {
            var pro = await productRepository.UpdateProducts(products);
            return pro;
        }

        [HttpDelete("Delete Products")]
        public async Task<IActionResult> DeleteProducts(int productId)
        {
            await productRepository.DeleteProducts(productId);
            return NoContent();
        }


    }
}
