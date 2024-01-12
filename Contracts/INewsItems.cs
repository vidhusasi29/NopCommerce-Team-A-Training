using Entities.Models.ContentManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface INewsItems
    {

        Task<IEnumerable<NewsItems>> GetNewsItemsList();
        Task<NewsItems> GetNewsItems(int GetNewsItemsById);
        Task<NewsItems> AddNewsItems(NewsItems NewsAdded);
        Task<NewsItems> UpdateNewsItems(NewsItems NewsUpdate);
        Task<bool> DeleteNewsItems(int DeleteNewsById);
    }
}