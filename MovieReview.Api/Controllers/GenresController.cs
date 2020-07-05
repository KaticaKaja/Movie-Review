using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Application;
using MovieReview.Application.Commands;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.Application.QueryDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public GenresController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/<GenresController>
        [HttpGet]
        public IActionResult Get([FromQuery] GenreSearch search,
            [FromServices] IGetGenresQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneGenreQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<GenresController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreDto dto, [FromServices] IAddGenre command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenreDto dto, [FromServices] IUpdateGenre command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGenre command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
