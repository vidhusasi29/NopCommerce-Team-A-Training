using Entities.Models.Catalog;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.ContentManagement
{
    public class NewsItems
    {
        [Key]
        public int Id { get; set; }


        public string? Title { get; set; }
        public bool Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        public DateTime Created_At { get; set; }
        public string? Created_By { get; set; }
        public DateTime Modified_At { get; set; }
        public string? Modified_By { get; set; }

        public bool Is_Deleted { get; set; }
        public int Productsid { get; set; }

        public virtual Products? Product_Id { get; set; }
    }
}
