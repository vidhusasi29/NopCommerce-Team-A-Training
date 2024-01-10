using Entities.Models.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Sales
{
    public class ReturnRequest
    {
        [Key]
        public int Id { get; set; }  
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public enum ReturnStatus 
        {
            Pending,
            Received,
            Items_Repaired,
            Items_Refunded,
            Canceled
        }
        public TimeOnly CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public TimeOnly ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }=false;
        public int Orderid { get; set; }
        public Order? Order { get; set; }//fk  
    }
}
