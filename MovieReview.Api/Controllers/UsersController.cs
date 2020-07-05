using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Application;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Commands;
using MovieReview.Application.QueryDto;
using MovieReview.Application.Queries;
using MovieReview.EfDataAccess;

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
        //[Authorize]
        public IActionResult Get([FromQuery] UserSearch search,
            [FromServices] IGetUsersQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }


        // GET: api/Users/5
        //[Authorize]
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id, [FromServices] IGetOneUserQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto, [FromServices] IAddUser command) // svi [register]
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [Authorize]
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto dto, [FromServices] IUpdateUser command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [Authorize]
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUser command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
