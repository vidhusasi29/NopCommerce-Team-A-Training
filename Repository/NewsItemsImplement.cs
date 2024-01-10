using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Contracts;
using Entities.Models;
using Entities.Models.ContentManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class NewsItemsImplement : INewsItems
    {

        private readonly ContextDB contextDB;

        public NewsItemsImplement(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        public async Task<IEnumerable<NewsItems>> GetNewsItems()
        {
            return await contextDB.NewsItems.ToListAsync();
        }
        public async Task<NewsItems> GetNewsItems(int GetNewsItemsById)
        {
            return await contextDB.NewsItems.
                FirstOrDefaultAsync(e => e.Id == GetNewsItemsById);
        }

        public async Task<NewsItems> AddNewsItems(NewsItems NewsAdded)
        {
            var result = await contextDB.NewsItems.AddAsync(NewsAdded);
            await contextDB.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<NewsItems> UpdateNewsItems(NewsItems NewsUpdate)
        {
            var result = await contextDB.NewsItems.
                FirstOrDefaultAsync(e => e.Id == NewsUpdate.Id);
            if (result != null)
            {
                result.Title = NewsUpdate.Title;
                result.Description = NewsUpdate.Description;
                result.Start_Date = NewsUpdate.Start_Date;
                result.End_Date = NewsUpdate.End_Date;

                await contextDB.SaveChangesAsync();

                return result;
            }

            return null;

        }
        public async Task<IActionResult> DeleteNewsItems(int DeleteNewsById)
        {
            var result = await contextDB.NewsItems.
                FirstOrDefaultAsync(e => e.Id == DeleteNewsById);
            if (result != null)
            {
                contextDB.NewsItems.Remove(result);
                await contextDB.SaveChangesAsync();
            }
            return null;
            
        }
    }
}
