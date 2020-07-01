using System;
using System.Collections.Generic;
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
        }
    }

    public class UploadDto
    {
        public IFormFile Image { get; set; }
    }
}
