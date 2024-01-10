using Contracts;
using Entities.Models;
using Entities.Models.Catalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Contracts.ICatalog;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContextDB contextDB;
        public CategoryRepository(ContextDB contextDB)
        {

            this.contextDB = contextDB;

        }

        public async Task<Categories> AddCategories(Categories categories)
        {
            var result = await contextDB.Categories.AddAsync(categories);
            await contextDB.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Categories> DeleteCategories(int categoryId)
        {

            var result = await contextDB.Categories
               .FirstOrDefaultAsync(C => C.Id == categoryId);

            if (result != null)
            {
                contextDB.Categories.Remove(result);
                await contextDB.SaveChangesAsync();
            }
            return null;
            
        }

        public async Task<IEnumerable<Categories>> GetCategories()
        {

            return await contextDB.Categories.ToListAsync();
        }

        public async Task<Categories> GetCategorybyId(int Id)
        {
            return await contextDB.Categories
                 .FirstOrDefaultAsync(c => c.Id == Id);
        }


        public async Task<Categories> UpdateCategories(Categories categories)
        {
            var result = await contextDB.Categories
                   .FirstOrDefaultAsync(C => C.Id == categories.Id);

            if (result != null)
            {
                result.Category_Name = categories.Category_Name;

                result.Created_At = categories.Created_At;
                result.Created_By = categories.Created_By;
                result.ModifiedBy = categories.ModifiedBy;
                result.ModifiedAt = categories.ModifiedAt;
                result.IsDeleted = categories.IsDeleted;


                await contextDB.SaveChangesAsync();

                return result;
            }

            return null;
        }


    }
}

