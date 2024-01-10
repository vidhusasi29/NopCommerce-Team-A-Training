using Entities.Models.Promotions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Contracts.IPromotions;

namespace NOP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IDiscounts _discount;
        private readonly IAffiliates _affiliate;
        private readonly INewsletter _newsLetter;
        private readonly ICampaigns _campaign;
        public PromotionsController(IDiscounts discount, IAffiliates affiliate, INewsletter newsLetter, ICampaigns campaign)
        {
            _discount = discount;
            _affiliate = affiliate;
            _newsLetter = newsLetter;
            _campaign = campaign;
        }

        // Discounts

        [HttpGet("Discounts-Search")]
        public async Task<IEnumerable<Discounts>> GetDiscounts()
        {
            var get = await _discount.GetDiscounts();
            return get;
        }

        [HttpGet("Discounts-SearchById")]
        public async Task<Discounts> GetDiscountById(int DiscountId)
        {
            var get = await _discount.GetDiscountById(DiscountId);
            return get;
        }

        [HttpPost("Discounts-AddNew")]
        public async Task<Discounts> AddDiscounts(Discounts discount)
        {
            Discounts obj = new Discounts();
            if (discount != null)
            {
                obj = await _discount.AddDiscounts(discount);
            }
            return obj;
        }

        [HttpPut("Discounts-Edit")]
        public async Task<Discounts> UpdateDiscounts(Discounts discount)
        {
            var update = await _discount.UpdateDiscounts(discount);
            return update;
        }

        // Affiliates

        [HttpGet("Affiliates-Search")]
        public async Task<IEnumerable<Affiliates>> GetAffiliates()
        {
            var get = await _affiliate.GetAffiliates();
            return get;
        }

        [HttpGet("Affiliates-SearchById")]
        public async Task<Affiliates> GetAffiliatesById(int AffiliateId)
        {
            var get = await _affiliate.GetAffiliatesById(AffiliateId);
            return get;
        }

        [HttpPost("Affiliates-AddNew")]
        public async Task<Affiliates> AddAffiliates(Affiliates affiliate)
        {
            Affiliates obj = new Affiliates();
            if (affiliate != null)
            {
                obj = await _affiliate.AddAffiliates(affiliate);
            }
            return obj;
        }

        [HttpPut("Affiliates-Edit")]
        public async Task<Affiliates> UpdateAffiliates(Affiliates affiliate)
        {
            var update = await _affiliate.UpdateAffiliates(affiliate);
            return update;
        }

        [HttpDelete("Affiliates-Delete")]
        public async Task<IActionResult> DeleteAffiliates(int id)
        {
            await _affiliate.DeleteAffiliates(id);
            return NoContent();
        }

        // News letter

        [HttpGet("News-Search")]
        public async Task<IEnumerable<NewsletterSubscribers>> GetNewsletter()
        {
            var get = await _newsLetter.GetNewsletter();
            return get;
        }

        [HttpPost("News-AddNew")]
        public async Task<NewsletterSubscribers> AddNews(NewsletterSubscribers news)
        {
            NewsletterSubscribers obj = new NewsletterSubscribers();
            if (news != null)
            {
                obj = await _newsLetter.AddNews(news);
            }
            return obj;
        }

        // Campaigns

        [HttpGet("Campaigns-Search")]
        public async Task<IEnumerable<Campaigns>> GetCampaigns()
        {
            var get = await _campaign.GetCampaigns();
            return get;
        }

        [HttpPost("Campaigns-AddNew")]
        public async Task<Campaigns> AddCampaigns(Campaigns campaign)
        {
            Campaigns obj = new Campaigns();
            if (campaign != null)
            {
                obj = await _campaign.AddCampaigns(campaign);
            }
            return obj;
        }
    }
}
