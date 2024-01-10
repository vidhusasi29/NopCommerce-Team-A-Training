using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Promotions
{
    public class Campaigns
    {

        [Key]
        public int Campaigns_ID { get; set; }
        public string? Campaigns_Name { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public DateTime Created_At { get; set; }
        public string? Created_By { get; set; }
        public string? Modified_By { get; set; }
        public DateTime Modified_At { get; set; }
        public bool IsDelete { get; set; }
    }
}
