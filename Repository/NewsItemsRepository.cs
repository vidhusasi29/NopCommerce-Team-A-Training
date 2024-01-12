using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Contracts;
using Entities.Models;
using Entities.Models.ContentManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class NewsItemsRepository : INewsItems
    {

        private readonly ContextDB contextDB;

        public NewsItemsRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        public async Task<IEnumerable<NewsItems>> GetNewsItemsList()
        {
            return await contextDB.NewsItems.Where(n => !n.Is_Deleted).ToListAsync();//checking soft delete
        }
        public async Task<NewsItems> GetNewsItems(int GetNewsItemsById)
        {
            return await contextDB.NewsItems.
                FirstOrDefaultAsync(e => e.Id == GetNewsItemsById && !e.Is_Deleted);//is deleted
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
                FirstOrDefaultAsync(e => e.Id == NewsUpdate.Id && !e.Is_Deleted);
            if (result != null)
            {
                result.Title = NewsUpdate.Title;
                result.Description = NewsUpdate.Description;
                result.Start_Date = NewsUpdate.Start_Date;
                result.End_Date = NewsUpdate.End_Date;

                await contextDB.SaveChangesAsync();

               
            }

            return result;//return the updated news items or null if result not found

        }
        public async Task<IActionResult> DeleteNewsItems(int DeleteNewsById)
        {
            var result = await contextDB.NewsItems.
                FirstOrDefaultAsync(e => e.Id == DeleteNewsById && !e.Is_Deleted);
            if (result != null)
            {
                result.Is_Deleted = true;// Set IsDeleted to true for soft delete
               // contextDB.NewsItems.Remove(result);
                await contextDB.SaveChangesAsync();
                return new OkResult();//entity is found and deleted
            }
            return new NotFoundResult();//entity is not found

        }
    }
}
