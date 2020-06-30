using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Api.Core;
using MovieReview.Application.DataTransfer;

namespace MovieReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
       
        private readonly JwtManager manager;

        public TokenController(JwtManager manager)
        {
            this.manager = manager;
        }

        // POST api/<TokenController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequestDto request)
        {
            var token = manager.MakeToken(request);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    

        
    }
}
