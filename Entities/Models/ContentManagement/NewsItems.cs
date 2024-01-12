using Entities.Models.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ContentManagement
{
    public class NewsItems
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="Title is required")]
        public string? Title { get; set; }
        public bool Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        //forign key property
        [ForeignKey("Products")]

        public int ProductsId { get; set; }

        //navigation property
        public virtual Products? Products { get; set; }//changed Product_Id to products
        public DateTime Created_At { get; set; }
        public string? Created_By { get; set; }
        public DateTime Modified_At { get; set; }
        public string? Modified_By { get; set; }

        public bool Is_Deleted { get; set; }
       
    }
}
