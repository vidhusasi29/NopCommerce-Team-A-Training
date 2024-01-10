using Contracts;
using Entities.Models;
using Entities.Models.Catalog;
using Entities.Models.Customers;
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
    public class ManufactureRepository : IManufacturerRepository
    {
        private readonly ContextDB contextDB;

        public ManufactureRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        public async Task<Manufacturers> AddManufacturers(Manufacturers manufacturers)
        {
            var result = await contextDB.Manufacturers.AddAsync(manufacturers);
            await contextDB.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IActionResult> DeleteManufacturers(int manufactureid)
        {
            var result = await contextDB.Manufacturers
                .FirstOrDefaultAsync(e => e.Id == manufactureid);
            if (result != null)
            {
                contextDB.Manufacturers.Remove(result);
                await contextDB.SaveChangesAsync();

            }
            return null;
            
        }

        public async Task<IEnumerable<Manufacturers>> GetManufacturer()
        {
            return await contextDB.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturers> GetManufacturerbyId(int Id)
        {
            return await contextDB.Manufacturers
               .FirstOrDefaultAsync(M => M.Id == Id);
        }

        public async Task<Manufacturers> UpdateManufacturers(Manufacturers manufacturers)
        {
            var result = await contextDB.Manufacturers
                 .FirstOrDefaultAsync(M => M.Id == manufacturers.Id);

            if (result != null)
            {
                result.Name = manufacturers.Name;

                result.Created_At = manufacturers.Created_At;
                result.Created_By = manufacturers.Created_By;
                result.ModifiedBy = manufacturers.ModifiedBy;
                result.ModifiedAt = manufacturers.ModifiedAt;
                result.IsDeleted = manufacturers.IsDeleted;


                await contextDB.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}

