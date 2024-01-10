using Contracts;
using Entities.Models;
using Entities.Models.Catalog;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using static Contracts.ICatalog;
using Microsoft.AspNetCore.Mvc;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
       
        private readonly ContextDB contextDB;

        public ProductRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }
        public async Task<Products> AddProducts(Products products)
        {
            
            var result = await contextDB.Products.AddAsync(products);
            await contextDB.SaveChangesAsync();
            
            return result.Entity;
           
        }

        public async Task<IActionResult> DeleteProducts(int productId)
        {
            var result = await contextDB.Products
               .FirstOrDefaultAsync(m => m.Id == productId);
            if (result != null)
            {
                contextDB.Products.Remove(result);
                await contextDB.SaveChangesAsync();
            }
            return null;
            
        }

        public async Task<Products> GetProductbyId(int Id)
        {

            return await contextDB.Products
               .FirstOrDefaultAsync(M => M.Id == Id);
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await contextDB.Products.ToListAsync();
        }


        public async Task<Products> UpdateProducts(Products products)
        {
            var result = await contextDB.Products
                 .FirstOrDefaultAsync(M => M.Id == products.Id);

            if (result != null)
            {
                result.Product_Name = products.Product_Name;

                result.Product_Attribute = products.Product_Attribute;
                result.Product_Tag = products.Product_Tag;
                result.Price = products.Price;
                result.ManufacturersId = products.ManufacturersId;
                result.VendorsId = products.VendorsId;
                result.DiscountsId = products.DiscountsId;
                result.Created_At = products.Created_At;
                result.Created_By = products.Created_By;
                result.ModifiedAt = products.ModifiedAt;
                result.ModifiedBy = products.ModifiedBy;
                result.IsDeleted = products.IsDeleted;

                await contextDB.SaveChangesAsync();

                return result;

            }

            return null;
        }

        
    }
}
