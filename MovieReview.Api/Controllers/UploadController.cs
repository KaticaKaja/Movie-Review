using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        // POST: api/Upload
        [HttpPost]
        public void Post([FromForm] UploadDto dto)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);
            var newName = guid + extension;
            var path = Path.Combine("wwwroot", "Images", newName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }

        }
    }

    public class UploadDto
    {
        public IFormFile Image { get; set; }
    }
}
