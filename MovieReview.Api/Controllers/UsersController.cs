using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Application;
using MovieReview.Application.CommandDto;
using MovieReview.Application.Commands;

namespace MovieReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public UsersController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get() // samo admin
        {
            return new string[] { "value1", "value2" };
        }

        [Authorize]
        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")] // admin i taj user
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] UserDto dto, [FromServices] IAddUser command) // svi [register]
        {
            executor.ExecuteCommand(command, dto);
        }

        [Authorize]
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) // admin, eventualno taj user
        {
        }
        [Authorize]
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id) // admin
        {
        }
    }
}
