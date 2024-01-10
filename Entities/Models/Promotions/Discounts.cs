using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Promotions
{
    public class Discounts
    {


        [Key]
        public int Discount_ID { get; set; }
        public string? Discount_Name { get; set; }
        public decimal Discount_Percent { get; set; }
        public string? Discount_Type { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime Created_At { get; set; }
        public string? Created_By { get; set; }
        public string? Modified_By { get; set; }
        public DateTime Modified_At { get; set; }
        public bool IsDelete { get; set; }
    }
}
