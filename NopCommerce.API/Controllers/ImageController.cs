using Entities.Models.Catalog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NopCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment { get; set; }
        public ImageUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult Post([FromForm] ProductImageUpload image)
        {
            Imagejoin obj = new Imagejoin();
            obj.prod = new List<Products>();
            obj.image = new ProductImageUpload();
            try
            {
                if (obj != null && image != null)
                {
                    obj.image.Id = image.Id;
                }
                obj.image.Name = "\\Upload\\" + image.files.FileName;

                if (image.files.Length > 0)
                {



                    // Check if the 'Uploads' folder exists, create it if not
                    if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\Upload"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\Upload\\");
                    }



                    // Save the file to the specified path
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\Upload\\" + image.files.FileName))
                    {
                        image.files.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    return Ok("Upload Done");
                }
                    

                    
                
                else
                {
                    return BadRequest("No files uploaded");
                }
            }finally { }
            
        }
        

            
    }





