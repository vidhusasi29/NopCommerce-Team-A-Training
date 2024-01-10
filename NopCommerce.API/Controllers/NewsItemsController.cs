using Contracts;
using Entities.Models.ContentManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NOP.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewsItemsController : ControllerBase
    {
        private readonly INewsItems _iNewsItems;

        public NewsItemsController(INewsItems inewsItems)
        {
            _iNewsItems = inewsItems;
        }

        // GET: api/NewsItems

        [HttpGet("GetNewsItems")]
        public async Task<IEnumerable<NewsItems>> GetNewsItems()
        {
            var newsitems = await _iNewsItems.GetNewsItems();
            return newsitems;
        }

        [HttpGet("GetNewsItemsById")]
        public async Task<ActionResult<NewsItems>> GetNewsItemsById(int Id)
        {
            var newsitem = await _iNewsItems.GetNewsItems(Id);
            return newsitem;
        }

        [HttpPost("AddNewsItems")]
        public async Task<ActionResult<NewsItems>> AddNewsItems(NewsItems newsItems)
        {
            NewsItems newsItems1 = new NewsItems();
            if (newsItems != null)
            {
                newsItems1.Id = 0;
                newsItems1 = await _iNewsItems.AddNewsItems(newsItems);
            }
            return newsItems1;
        }

        [HttpPut("UpdateNewsItems/{id}")]
        public async Task<ActionResult<NewsItems>> UpdateNewsItems(int Id, NewsItems newsItems)
        {
            if (Id != newsItems.Id)
            {
                return BadRequest("Mismatched IDs");
            }
            var existingNewsItems = await _iNewsItems.GetNewsItems(newsItems.Id);

            if (existingNewsItems == null)
            {
                return NotFound();
            }

            var updatedNewsItems = await _iNewsItems.UpdateNewsItems(existingNewsItems);
            return Ok(updatedNewsItems);
        }

        [HttpDelete("DeleteNewsItems/{Id}")]
        public async Task<ActionResult<NewsItems>> DeleteNewsItems(int Id)
        {
            var existingNewsItems = await _iNewsItems.GetNewsItems();
            if (!existingNewsItems.Any())
            {
                return NotFound();
            }
            await _iNewsItems.DeleteNewsItems(Id);

            return Ok(existingNewsItems);


        }
    }
}
