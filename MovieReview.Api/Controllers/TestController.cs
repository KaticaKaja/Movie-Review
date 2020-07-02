using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var movies = new Faker<ActorMovie>();
            //movies.RuleFor(x => x.UserId, f => f.Random.Int(7, 57));
            //movies.RuleFor(x => x.MovieId, f => f.Random.Int(1, 30));
            //movies.RuleFor(x => x.Title, f => f.Lorem.Sentence(6));
            //movies.RuleFor(x => x.Text, f => f.Lorem.Sentences(10));
            //movies.RuleFor(x => x.MovieRating, f => f.Random.Int(1, 5));
            //movies.RuleFor(x => x.MovieId, f => f.Random.Int(1, 30));
            //movies.RuleFor(x => x.GenreId, f => f.Random.Int(101,110));
            //movies.RuleFor(x => x.FirstName, f => f.Person.FirstName);
            //movies.RuleFor(x => x.LastName, f => f.Person.LastName);
            //movies.RuleFor(x => x.ShortBio, f => f.Lorem.Sentence(10));
            movies.RuleFor(x => x.ActorId, f => f.Random.Int(25, 44));
            movies.RuleFor(x => x.MovieId, f => f.Random.Int(1, 30));
            movies.RuleFor(x => x.CharacterName, f => f.Person.FullName);
            movies.RuleFor(x => x.IsActive, f => true);
            movies.RuleFor(x => x.IsDeleted, f => false);
            movies.RuleFor(x => x.CreatedAt, f => f.Date.Past(5, DateTime.Now));
            var moviesf = movies.Generate(10);
            context.ActorMovies.AddRange(moviesf);
            context.SaveChanges();
            return Ok(moviesf);
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
