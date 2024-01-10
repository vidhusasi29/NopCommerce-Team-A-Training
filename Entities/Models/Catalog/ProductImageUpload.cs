using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Catalog
{
    public class ProductImageUpload
    {
            public int Id { get; set; }

            public string Name { get; set; }

            public IFormFile files { get; set; }

            public int ProductsId { get; set; }
            
        
    }
    public class Imagejoin
    {
        public ProductImageUpload image{ get; set; }
        public Products product{ get; set; }
        public List<Products> prod { get; set; }
    }


}
