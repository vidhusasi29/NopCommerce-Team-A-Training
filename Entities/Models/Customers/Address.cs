using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Customers
{
    public class Address
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string name { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Addresses { get; set; }

        public int Postal_code { get; set; }
        public int Phone_number { get; set; }
        public DateTime Created_at { get; set; }
        public string? Created_By { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int CustomerRegistrationid { get; set; }
        public virtual CustomerRegistration? Customer_ID { get; set; }
    }
}
