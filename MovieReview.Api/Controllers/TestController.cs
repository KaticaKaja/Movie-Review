using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Domain;
using MovieReview.EfDataAccess;

namespace MovieReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MovieReviewContext context;
        public TestController(MovieReviewContext context)
        {
            this.context = context;
        }
        // GET: api/Test
        [HttpGet]
        public IActionResult Get()
        {
            var usersFaker = new Faker<User>();

            usersFaker.RuleFor(x => x.FirstName, f => f.Name.FirstName());
            usersFaker.RuleFor(x => x.LastName, f => f.Name.LastName());
            usersFaker.RuleFor(x => x.Username, f => f.Internet.UserName());
            usersFaker.RuleFor(x => x.Email, f => f.Internet.Email());
            usersFaker.RuleFor(x => x.Password, f => f.Internet.Password());
            usersFaker.RuleFor(x => x.IsActive, f => true);
            usersFaker.RuleFor(x => x.IsDeleted, f => false);
            usersFaker.RuleFor(x => x.CreatedAt, f => f.Date.Past(5, DateTime.Now));
            var users = usersFaker.Generate(50);
            context.Users.AddRange(users);
            context.SaveChanges();
            return Ok(users);
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "GetTest")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
