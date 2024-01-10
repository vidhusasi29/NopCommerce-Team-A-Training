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

        public string Post([FromForm] ProductImageUpload image)
        {
            try
            {
                if (image.files.Length > 0)
                {
                    string Path = _webHostEnvironment.WebRootPath + "\\Upload\\";
                    if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\Upload"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\Upload\\");
                    }

                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.ContentRootPath + "\\Upload\\" + image.files.FileName))
                    {
                        image.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Upload Done";
                    }


                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("{fileName}")]
        public async Task<ActionResult> Get([FromRoute] string fileName)
        {
            string Path = _webHostEnvironment.ContentRootPath + "\\Upload\\";
            var FilePath = Path + fileName + ".jpg";
            if (System.IO.File.Exists(FilePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(FilePath);
                return File(b, "image/jpg");
            }
            return NotFound(); ;
        }
    }
}





