using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Promotions
{
    public class Affiliates
    {

        [Key]
        public int Affiliate_ID { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Email { get; set; }
        public string? Company { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? Region { get; set; }
        public string? Address { get; set; }
        public int ZipCode { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime Created_At { get; set; }
        public string? Created_By { get; set; }
        public string? Modified_By { get; set; }
        public DateTime Modified_At { get; set; }
        public bool IsDelete { get; set; }
    }
}
