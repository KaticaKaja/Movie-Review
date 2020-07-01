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

namespace MovieReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public ReviewsController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }
        // GET: api/Reviews
        [HttpGet]
        public IActionResult Get([FromQuery] ReviewSearch search,
            [FromServices] IGetReviewsQuery query)
        {
            return Ok(executor.ExecuteQuery(query, search));
        }

        // GET: api/Reviews/5
        [HttpGet("{id}", Name = "GetReview")]
        public IActionResult Get(int id, [FromServices] IGetOneReviewQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST: api/Reviews
        [HttpPost]
        public IActionResult Post([FromBody] ReviewDto dto, [FromServices] IAddReview command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReviewDto dto, [FromServices] IUpdateReview command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReview command)
        {
            executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
