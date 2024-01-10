using Entities.Models.Catalog;
using Entities.Models.Promotions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ICatalog
    {
        public interface ICategoryRepository
        {
            Task<IEnumerable<Categories>> GetCategories();
            Task<Categories> GetCategorybyId(int Id);
            Task<Categories> AddCategories(Categories categories);
            Task<Categories> UpdateCategories(Categories categories);
            Task<Categories> DeleteCategories(int categoryid);
        }

        public interface IManufacturerRepository
        {
            Task<IEnumerable<Manufacturers>> GetManufacturer();
            Task<Manufacturers> GetManufacturerbyId(int Id);
            Task<Manufacturers> AddManufacturers(Manufacturers manufacturers);
            Task<Manufacturers> UpdateManufacturers(Manufacturers manufacturers);
            Task<IActionResult> DeleteManufacturers(int manufactureid);
        }

        public interface IProductRepository
        {
            Task<IEnumerable<Products>> GetProducts();
            Task<Products> GetProductbyId(int Id);
            Task<Products> AddProducts(Products products);
            Task<Products> UpdateProducts(Products products);
            Task<IActionResult> DeleteProducts(int productId);
            
        }
    }
}
