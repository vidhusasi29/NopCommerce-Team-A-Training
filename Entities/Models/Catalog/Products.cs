using Entities.Models.Customers;
using Entities.Models.Promotions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Catalog
{
    public class Products
    {

        [Key]
        public int Id { get; set; }
        public string Product_Name { get; set; }

        
        public DateTime Created_At { get; set; }
        public string Created_By { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        
        public string Product_Tag { get; set; }
        public string Description { get; set; }
        public string Product_Attribute { get; set; }
        public double Price { get; set; }
        public int ManufacturersId { get; set; }
        public virtual Manufacturers? Manufacturers { get; set; }
        public int CategoriesId { get; set; }
        public virtual Categories? Categories { get; set; }
        public int VendorsId { get; set; }
        public virtual Vendors? vendors { get; set; }
        public int DiscountsId { get; set; }
        public virtual Discounts? Discounts { get; set; }
        

    }
}
