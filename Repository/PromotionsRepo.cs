using Contracts;
using Entities.Models;
using Entities.Models.Promotions;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using static Contracts.IPromotions;

namespace Repository
{
    public class PromotionsRepo : IDiscounts, IAffiliates, INewsletter, ICampaigns
    {
        private readonly ContextDB _contextDB;
        public PromotionsRepo(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }
        // Discounts
        public async Task<IEnumerable<Discounts>> GetDiscounts()
        {
            return await _contextDB.Discounts.ToListAsync();
        }
        public async Task<Discounts> GetDiscountById(int DiscountId)
        {
            return await _contextDB.Discounts.FirstOrDefaultAsync(e => e.Discount_ID == DiscountId);
        }
        public async Task<Discounts> AddDiscounts(Discounts discount)
        {
            var add = await _contextDB.Discounts.AddAsync(discount);
            await _contextDB.SaveChangesAsync();
            return add.Entity;
        }
        public async Task<Discounts> UpdateDiscounts(Discounts discount)
        {
            var x = await _contextDB.Discounts
                .FirstOrDefaultAsync(e => e.Discount_ID == discount.Discount_ID);

            if (x != null)
            {
                x.Discount_Name = discount.Discount_Name;
                x.Discount_Percent = discount.Discount_Percent;
                x.Discount_Type = discount.Discount_Type;
                x.Start_Date = discount.Start_Date;
                x.End_Date = discount.End_Date;
                x.Created_At = discount.Created_At;
                x.Created_By = discount.Created_By;
                x.Modified_By = discount.Modified_By;
                x.Modified_At = discount.Modified_At;
                x.IsDelete = discount.IsDelete;

                await _contextDB.SaveChangesAsync();
                return x;
            }
            return null;
        }

        // Affiliates
        public async Task<IEnumerable<Affiliates>> GetAffiliates()
        {
            return await _contextDB.Affiliates.ToListAsync();
        }
        public async Task<Affiliates> GetAffiliatesById(int AffiliateId)
        {
            return await _contextDB.Affiliates.FirstOrDefaultAsync(e => e.Affiliate_ID == AffiliateId);
        }
        public async Task<Affiliates> AddAffiliates(Affiliates affiliate)
        {
            var add = await _contextDB.Affiliates.AddAsync(affiliate);
            await _contextDB.SaveChangesAsync();
            return add.Entity;
        }
        public async Task<Affiliates> UpdateAffiliates(Affiliates affiliate)
        {
            var x = await _contextDB.Affiliates
                .FirstOrDefaultAsync(e => e.Affiliate_ID == affiliate.Affiliate_ID);

            if (x != null)
            {
                x.First_Name = affiliate.First_Name;
                x.Last_Name = affiliate.Last_Name;
                x.Email = affiliate.Email;
                x.Company = affiliate.Company;
                x.State = affiliate.State;
                x.Region = affiliate.Region;
                x.Address = affiliate.Address;
                x.ZipCode = affiliate.ZipCode;
                x.PhoneNumber = affiliate.PhoneNumber;
                x.Created_At = affiliate.Created_At;
                x.Created_By = affiliate.Created_By;
                x.Modified_By = affiliate.Modified_By;
                x.Modified_At = affiliate.Modified_At;
                x.IsDelete = affiliate.IsDelete;

                await _contextDB.SaveChangesAsync();
                return x;
            }
            return null;
        }
        public async Task DeleteAffiliates(int affiliateId)
        {
            var x = await _contextDB.Affiliates
                .FirstOrDefaultAsync(e => e.Affiliate_ID == affiliateId);
            if (x != null)
            {
                _contextDB.Affiliates.Remove(x);
                await _contextDB.SaveChangesAsync();
            }
        }

        // NewsletterSubscribers
        public async Task<IEnumerable<NewsletterSubscribers>> GetNewsletter()
        {
            return await _contextDB.News.ToListAsync();
        }
        public async Task<NewsletterSubscribers> AddNews(NewsletterSubscribers news)
        {
            var add = await _contextDB.News.AddAsync(news);
            await _contextDB.SaveChangesAsync();
            return add.Entity;
        }

        // Campaigns
        public async Task<IEnumerable<Campaigns>> GetCampaigns()
        {
            return await _contextDB.Campaigns.ToListAsync();
        }
        public async Task<Campaigns> AddCampaigns(Campaigns campaign)
        {
            var add = await _contextDB.Campaigns.AddAsync(campaign);
            await _contextDB.SaveChangesAsync();
            return add.Entity;
        }
    }
}

