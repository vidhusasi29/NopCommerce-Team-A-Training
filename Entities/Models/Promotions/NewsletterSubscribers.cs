using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Promotions
{
    public class NewsletterSubscribers
    {

        [Key]
        public int News_ID { get; set; }
        public string? Email { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime Created_At { get; set; }
        public string? Created_By { get; set; }
        public string? Modified_By { get; set; }
        public DateTime Modified_At { get; set; }
        public bool IsDelete { get; set; }
    }
}
