using Entities.Models.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPromotions
    {
        public interface IDiscounts
        {
            Task<IEnumerable<Discounts>> GetDiscounts(); // search
            Task<Discounts> GetDiscountById(int DiscountId); // search by id
            Task<Discounts> AddDiscounts(Discounts discount); // add new
            Task<Discounts> UpdateDiscounts(Discounts discount); // edit
            //Task DeleteDiscounts(int DiscountId); // delete
        }
        public interface IAffiliates
        {
            Task<IEnumerable<Affiliates>> GetAffiliates(); // search
            Task<Affiliates> GetAffiliatesById(int AffiliateId); // search by id
            Task<Affiliates> AddAffiliates(Affiliates affiliate); // add new
            Task<Affiliates> UpdateAffiliates(Affiliates affiliate); // edit
            Task DeleteAffiliates(int affiliateId); // delete
        }
        public interface INewsletter
        {
            Task<IEnumerable<NewsletterSubscribers>> GetNewsletter(); // search
            //Task<NewsletterSubscribers> GetNewsletterById(int newsId); // search by id
            Task<NewsletterSubscribers> AddNews(NewsletterSubscribers news); // add new
            //Task<NewsletterSubscribers> UpdateNews(NewsletterSubscribers news); // edit
            //Task DeleteNews(int newsId); // delete
        }
        public interface ICampaigns
        {
            Task<IEnumerable<Campaigns>> GetCampaigns(); // search
            //Task<Campaigns> GetCampaignsById(int campaignId); // search by id
            Task<Campaigns> AddCampaigns(Campaigns campaign); // add new
            //Task<Campaigns> UpdateCampaigns(Campaigns campaign); // edit
            //Task DeleteCampaigns(int campaignId); // delete
        }
    }
}

