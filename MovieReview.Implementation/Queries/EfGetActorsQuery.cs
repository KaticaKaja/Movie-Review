using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieReview.Application.DataTransfer;
using MovieReview.Application.Queries;
using MovieReview.Application.QueryDto;
using MovieReview.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieReview.Implementation.Queries
{
    public class EfGetActorsQuery : IGetActorsQuery
    {
        private readonly MovieReviewContext _context;
        private readonly IMapper mapper;

        public EfGetActorsQuery(MovieReviewContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public int Id => 24;

        public string Name => "Get Actors";

        public PagedResponse<ActorDto> Execute(ActorSearch search)
        {
            var query = _context.Actors.Include(x=>x.ActorMovies).ThenInclude(am=>am.Movie).AsQueryable();

            if (!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor)
                )
            {
                query = query.Where(x => (x.FirstName + " " + x.LastName).ToLower().Contains(search.Actor.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.Movie) || !string.IsNullOrWhiteSpace(search.Movie)
                )
            {
                query = query.Where(x => x.ActorMovies.Any(am => am.Movie.Title.ToLower().Contains(search.Movie)));
            }
            var skipCount = search.PerPage * (search.Page - 1);

            var reponse = new PagedResponse<ActorDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => mapper.Map<ActorDto>(x)).ToList()
            };

            return reponse;
        }
    }
}
