using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.Application;
using MovieReview.Application.Commands;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.Application.QueryDto;

namespace MovieReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public MoviesController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/Movies
        [HttpGet]
        public IActionResult Get([FromQuery] MovieSearch search,
            [FromServices] IGetMoviesQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult Get(int id, [FromServices] IGetOneMovieQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Movies
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] MovieDto dto, [FromServices] IAddMovie command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] MovieDto dto, [FromServices] IUpdateMovie command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] IDeleteMovie command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
