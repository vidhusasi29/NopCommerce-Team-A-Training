using Entities.Models.ContentManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Customers
{
    public class CustomerRegistration
    {


        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Required]
        public string? First_name { get; set; }
        [Required]
        public string? Last_name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public int NewsItemsid { get; set; }

        public virtual NewsItems? NewsItems { get; set; }
        public int Vendorsid { get; set; }


        public virtual Vendors? vendor { get; set; }

        public DateTime created_at { get; set; }
        public string? Created_By { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
