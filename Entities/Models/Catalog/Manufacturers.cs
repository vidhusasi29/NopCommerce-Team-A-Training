using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Catalog
{
    public class Manufacturers
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public DateTime Created_At { get; set; }
        public string? Created_By { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
